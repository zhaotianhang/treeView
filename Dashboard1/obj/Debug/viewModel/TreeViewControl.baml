   M S B A M L   `   `   `  ����E  ADashboard1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Dashboard1
Dashboard1  5      *    $Dashboard1.viewModel.TreeViewControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $localclr-namespace:Dashboard1  5      -   5          � 	Resources  5	         testViewSource  menuViewSource  ContextMenu m�Name m� Command m� InputGestureText  ContextMenu1  ContractContextMenu �� Source �� Path �� DataType'  !MaterialDesignThemes.Wpf.PopupBox  ContextMenu111   PlacementMode   PopupContent�� 5
   
   %*  &	        &	      &	 &     &	 �    &	 D    7  &	 �    �� 5      6#   �� 5      6#   �� 5      .@�5      m� -   5        $��添加新任务��5      6+   �� 5      6   m� 5      -   5        $��添加子项��5      6*   �� 5      6   m� 5      $ MenuCopyItem��6   $��复制��61   $
 Copy��6=   $ Ctrl+C��6L   m� 5      $ MenuPasteItem��6   $��粘贴��62   $ Paste��6>   $ Ctrl+V��6N   m� 5      $ MenuDeleteItem��6   $��删除��63   $ Delete��6?   $ Delete��6P   �� 5      6   m� 5      $��reName��6   -   5        $��	重命名��5   )   66   �� 5      6   m� 5      $��p��6   $��属性��6$   5      �� 5      .@�5      m� $��复制��6   $
 Copy��6(   $ Ctrl+C��67   m� 5      $��粘贴��6   $ Paste��6(   $ Ctrl+V��68   m� 5      $��删除��6   $ Delete��6(   $ Delete��69   �� 5      6   m� 5      $��删除任务��6   $ Delete��6)   �� 5       6   m� 5!      -   5        $��	重命名��5!      6(   �� 5"      6   m� 5#      $��属性��6   5$      �� 5%      -   5        ��5%   6   �� 8   $ 	MenuItems���5&      �� 5'      " m�6#   (��       *,m�+).R�5(      �� ��6$   �� *Name+5)      5+        5,      $��Right=�5-      $ BottomAndAlignRightEdges=�5.      . 5/      �� .@�50      �� .��6"   Hello World52      �� 53      .��6"   
Nice Popup55      �� 56      .��6"   
Goodbye.58      59      5:      5;      	 J� CommandBindings	 5=      )  #System.Windows.Input.CommandBinding  5>   
   -   5        Command_Copy��
   Command$

 Copy��5>   /   6c     5?   
   -   5        Command_Paste��$
 Paste��5?   0   6f     5@   
   -	   5        Command_Delete��$
 Delete��5@   1   6i   .��5B      � $��0 0 1 0 q�6   ��5C   
   �� 5D       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5E      �  � Color$ 	LightGray��6    � Offset$ 1Q�61   � 5F      $ 	#FFE6E6E6��6   5G       � RowDefinitions 5I   
   �� 5J      $��40 �6   �� 5K      $��* �6    J� Effect 5M   
   3  -System.Windows.Media.Effects.DropShadowEffect  5N         
BlurRadius$ 20Q�6      Color$ 	#FFDEDEDE��6/      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y   .+�5Q   
   � ���	#FF6E6E75.+�5R      �� $��设备列表��6   $��Center=�6$   $��Center=�6A   $��Microsoft YaHei)�6\   ���	#FF43434B$��16(�6�   5S      R� 5U   
   -
   5         R�Name$ departmentTree��5W   M   $	��220��5V      $��1��6   ���	#FF81818A��5W      �� # [  ��5h      �� 5i       �� ItemsSource 6+   �� *ChirdrenTests+.R�5j      �� -   5         �� Orientation$ 
Horizontal=�5j   "   $��0,2,0,2q�6;   .+�5k      '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FF993636   Kind 6J   �� *CateId+    Dashboard1.ImageConverter1   Instance �� 	Converter# Z � 5n      .+�5o      �� $��8,0,0,0q�6(   $
��Left=�6:   $��Center=�6U   $��14(�6p   ��6~   �� $
 Name� �� Mode$ TwoWay=�5p   "   �� 5q      -   5        $��8,0,0,0q�5q   &   $
��Left=�67   $��Center=�6R   $��14(�6m   $y�	Collapsed=�6�   ��6{   �� $
 Name�$ TwoWay=�6O  5r      5s      5t      5v      5w      5x      