   M S B A M L   `   `   `  ����E  ADashboard1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Dashboard1
Dashboard1  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 65       Dashboard1.DataPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Dashboard1     5      DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     65     � 	Resources  5	         seriesViewSource  categoryViewSource  categoryProductsViewSource �� Source �� Source�� 5
   
   %z   &	        &	      &	 &     7  �� 5      6#   �� 5      6#   �� 5       5      �� *
Products+8   5      .��5      � -   5         � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ categoryDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��13,13,43,100q�5         RowDetailsVisibilityMode$ VisibleWhenSelected=�6!   ��5      �� # [    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Category Id��5      
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 SizeToHeader 62      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *
CategoryId+5        5      $
	 Name��6B   $
 * 5        5   )   �� *Name+5       5"        5#      -   5        $ productsDataGrid��5#       .   . $��13,205,43,108q�5&      $ VisibleWhenSelected=�6"    J� RenderTransformOrigin$ 0.488,0.251&�5'      ��5%      �� # [  5(        5)      $	 Category Id��5*      $
 SizeToHeader 62    .  5)   )   �� *
CategoryId+5+        5,      $	 
Product Id��6G   $
 SizeToHeader 5-       .  5,   )   �� *	ProductId+5-   2     5.      $
	 Name��6B   $
 * 6P    6)   �� *Name+6P     5/      $	 Value��6C   $
 * 6R    6)   �� *Value+6R   51      �� 52      -   5        $
��Save��52      $��Center=�6$   $��	0,100,0,0q�6A   $��30��53      $	��123��6+   54      #  LiveCharts.Wpf.CartesianChart  55   
   -   5          Name$ cartesianChart��55      $��1��66   $��30 5 30 200q�6F   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6u      Series 6[   �� *series+   AxisX 57        LiveCharts.Wpf.Axis     Title$
 x轴��6      Labels 6&   �� *labels+   AxisY 5:        $
 y轴��6      LabelFormatter 6&   �� *
yFormatter+5<      5=      5>      