﻿// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    /// <summary>
    /// The UniformGrid spaces items evenly.
    /// </summary>
    public partial class UniformGrid
    {
        /// <summary>
        /// Determines if this element in the grid participates in the auto-layout algorithm.
        /// </summary>
        public static readonly DependencyProperty AutoLayoutProperty =
            DependencyProperty.RegisterAttached(
              "AutoLayout",
              typeof(bool?),
              typeof(UniformGrid),
              new PropertyMetadata(null));

        /// <summary>
        /// Sets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// Though it its required to use this property to force an element to the 0, 0 position.
        /// </summary>
        /// <param name="element"><see cref="FrameworkElement"/></param>
        /// <param name="value">A true value indicates this item should be automatically arranged.</param>
        public static void SetAutoLayout(FrameworkElement element, bool? value)
        {
            element.SetValue(AutoLayoutProperty, value);
        }

        /// <summary>
        /// Gets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// </summary>
        /// <param name="element"><see cref="FrameworkElement"/></param>
        /// <returns>A true value indicates this item should be automatically arranged.</returns>
        public static bool? GetAutoLayout(FrameworkElement element)
        {
            return (bool?)element.GetValue(AutoLayoutProperty);
        }

        /// <summary>
        /// Sets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// </summary>
        /// <param name="element"><see cref="ColumnDefinition"/></param>
        /// <param name="value">A true value indicates this item should be automatically arranged.</param>
        public static void SetAutoLayout(ColumnDefinition element, bool? value)
        {
            element.SetValue(AutoLayoutProperty, value);
        }

        /// <summary>
        /// Gets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// </summary>
        /// <param name="element"><see cref="ColumnDefinition"/></param>
        /// <returns>A true value indicates this item should be automatically arranged.</returns>
        public static bool? GetAutoLayout(ColumnDefinition element)
        {
            return (bool?)element.GetValue(AutoLayoutProperty);
        }

        /// <summary>
        /// Sets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// </summary>
        /// <param name="element"><see cref="RowDefinition"/></param>
        /// <param name="value">A true value indicates this item should be automatically arranged.</param>
        public static void SetAutoLayout(RowDefinition element, bool? value)
        {
            element.SetValue(AutoLayoutProperty, value);
        }

        /// <summary>
        /// Gets the AutoLayout Attached Property Value. Used internally to track items which need to be arranged vs. fixed in place.
        /// </summary>
        /// <param name="element"><see cref="RowDefinition"/></param>
        /// <returns>A true value indicates this item should be automatically arranged.</returns>
        public static bool? GetAutoLayout(RowDefinition element)
        {
            return (bool?)element.GetValue(AutoLayoutProperty);
        }

        //// This Property is for ColumnDefinition (DependencyObject) vs. the Grid's FrameworkElement attached property.
        #pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// Determines if this element in the grid participates in the auto-layout algorithm.
        /// </summary>
        public static readonly DependencyProperty ColumnProperty =
        #pragma warning restore CS0108 // Member hides inherited member; missing new keyword
            DependencyProperty.RegisterAttached(
              "Column",
              typeof(int),
              typeof(UniformGrid),
              new PropertyMetadata(null));

        /// <summary>
        /// Sets the Column Attached Property Value.
        /// </summary>
        /// <param name="element"><see cref="ColumnDefinition"/></param>
        /// <param name="value">Zero-based Index of column for this ColumnDefinition.</param>
        public static void SetColumn(ColumnDefinition element, int value)
        {
            element.SetValue(ColumnProperty, value);
        }

        /// <summary>
        /// Gets the Column Attached Property Value.
        /// </summary>
        /// <param name="element"><see cref="ColumnDefinition"/></param>
        /// <returns>Specified column index for the ColumnDefinition.</returns>
        public static int GetColumn(ColumnDefinition element)
        {
            return (int)element.GetValue(ColumnProperty);
        }

        //// This Property is for RowDefinition (DependencyObject) vs. the Grid's FrameworkElement attached property.
        #pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// Determines if this element in the grid participates in the auto-layout algorithm.
        /// </summary>
        public static readonly DependencyProperty RowProperty =
        #pragma warning restore CS0108 // Member hides inherited member; missing new keyword
            DependencyProperty.RegisterAttached(
              "Row",
              typeof(int),
              typeof(UniformGrid),
              new PropertyMetadata(null));

        /// <summary>
        /// Sets the Row Attached Property Value.
        /// </summary>
        /// <param name="element"><see cref="RowDefinition"/></param>
        /// <param name="value">Zero-based Index of row for this RowDefinition.</param>
        public static void SetRow(RowDefinition element, int value)
        {
            element.SetValue(RowProperty, value);
        }

        /// <summary>
        /// Gets the Row Attached Property Value.
        /// </summary>
        /// <param name="element"><see cref="RowDefinition"/></param>
        /// <returns>Specified row index for the RowDefinition.</returns>
        public static int GetRow(RowDefinition element)
        {
            return (int)element.GetValue(RowProperty);
        }

        /// <summary>
        /// Identifies the <see cref="Columns"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register(nameof(Columns), typeof(int), typeof(UniformGrid), new PropertyMetadata(0, OnColumnsChanged));

        /// <summary>
        /// Identifies the <see cref="FirstColumn"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty FirstColumnProperty =
            DependencyProperty.Register(nameof(FirstColumn), typeof(int), typeof(UniformGrid), new PropertyMetadata(0, OnColumnsChanged));

        /// <summary>
        /// Identifies the <see cref="Orientation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(UniformGrid), new PropertyMetadata(Orientation.Horizontal));

        /// <summary>
        /// Identifies the <see cref="Rows"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register(nameof(Rows), typeof(int), typeof(UniformGrid), new PropertyMetadata(0));

        private static void OnColumnsChanged(DependencyObject d, object newValue)
        {
            var self = d as UniformGrid;

            if (self.FirstColumn >= self.Columns)
            {
                ////self.FirstColumn = 0;
            }

            ////self.RecalculateLayout();
        }

        /// <summary>
        /// Gets or sets the number of columns in the UniformGrid.
        /// </summary>
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the starting column offset for the first row of the UniformGrid.
        /// </summary>
        public int FirstColumn
        {
            get { return (int)GetValue(FirstColumnProperty); }
            set { SetValue(FirstColumnProperty, value); }
        }

        /// <summary>
        /// Gets or sets the orientation of the grid. When <see cref="Orientation.Vertical"/>,
        /// will transpose the layout of automatically arranged items such that they start from
        /// top to bottom then based on <see cref="FlowDirection"/>.
        /// Defaults to <see cref="Orientation.Horizontal"/>.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Gets or sets the number of rows in the UniformGrid.
        /// </summary>
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
    }
}
