   M S B A M L   `   `   `  ����L  HWpfChinookDataApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfChinookDataAppWpfChinookDataApp  5   	   +    %WpfChinookDataApp.ImportDelimitedData   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.33.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfChinookDataApp     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$  Import delimited data��5	   	   $	��750��6'   $	��900��64    � 
ResizeMode$ NoResize=�6@      backgroundcolor#��[  6V   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��5,5,5,5q�6   $��2q�6$   $��File to import:��60   $��0��6I   $��2��6V   .��5      �  5      �� 5      $��8* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6   $��Center=�6*   $��Stretch=�6E   $��5q�6c   �� 5      $��1��6   $
��Left=�6)   $��Center=�6D   $��5q�6_   $
��Bold"�6j   $��Italic$�6|   $��	Load File��6�   5      5       �� 5"   
   $��1��6   $��0��6"   $��0,0,0,0q�62   $��2��6C   .+�5#      �  5$      �� 5%      $��* �6'   �� 5&      $��* �6'    5(      �� 5)      $��* �6$   �� 5*      $��* �6$   �� 5+      $��* �6$   �� 5,      $��* �6$   .+�5/      �� $��ComboBox Caption:��6   $��Center=�6a   $��Center=�6~   $��11(�6�    �� Target 64   ��  �� ElementName$ TextDelimiter��6�   �� 50      $��1��6   $��0��6%   $��	Encoding:��65   $
��Left=�6u   $��Center=�6�   $��11(�6�   $��49,0,0,0q�6�    6I   �� $ TextEncoding��6�   �� 51      $��2��6   $��0��6%   $��Quote stripping:��65   $
��Left=�6~   $��Center=�6�   $��11(�6�   $��18,0,0,0q�6�    6P   �� $ QuoteStripping��6�   �� 52      $��3��6   $��0��6%   $��Decimal separator:��65   $
��Left=�6�   $��Center=�6�   $��11(�6�   $��7,0,0,0q�6�    6R   �� $ DecimalSeparator��6�   �� 54      -   5         ��Name$ TextDelimiter��54   8   $��0��6   $��1��6(    �� Text$ 
My Cities:��6O    �� 
IsEditable$ False��6a   	 �� 
IsReadOnly$
	 true��6t   $��5,5,5,5q�6�   $��5,5,5,5q�6�   $��Center=�6�   $��4��6�   $��11(�6�   �� 55      -   5        $ TextEncoding��55   8   $��1��6   $��1��6(   $ 	Encoding:��6O   $ False��6`   $
	 true��6s   $��5,5,5,5q�6�   $��5,5,5,5q�6�   $��Center=�6�   $��4��6�   $��11(�6�   �� 56      -   5        $ QuoteStripping��56   8   $��2��6   $��1��6(   $ Quote stripping:��6P   $ False��6h   $
	 true��6{   $��5,5,5,5q�6�   $��5,5,5,5q�6�   $��Center=�6�   $��4��6�   $��11(�6�   �� 57      -   5        $ DecimalSeparator��57   8   $��3��6   $��1��6(   $ Decimal separator:��6R   $ False��6l   $
	 true��6   $��5,5,5,5q�6�   $��5,5,5,5q�6�   $��Center=�6�   $��4��6�   $��11(�6�   58      59      �� 5;   
   $��0��6   $��3��6%   $��10q�62   .+�5<      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 	schemacol��5<         AutoGenerateColumns$ False��6*      CanUserAddRows$ False��5=         CanUserDeleteRows$ False��5>         CanUserSortColumns$ False��5?         CanUserReorderColumns$
 True��5@      $
��Left=�5A      $��Center=�5B         	CellStyle 5C      �� 5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      -   5        textcol��,  &System.Windows.Controls.DataGridColumn   Header$ Column��5G   S      CanUserResize$ False��6c      CanUserSort$ False��6y      CanUserReorder$ False��6�      
IsReadOnly$
 True��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Name+   	CellStyle 5H      �� 5I       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6$   .�5J   "   ��  �� Property � �� �� Value
 �����5K   !   5L      5N      4  .System.Windows.Controls.DataGridComboBoxColumn  5O      -   5        combocol��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 5O   ?      SelectedValuePath$	 Key��6K      DisplayMemberPath$ Value��6c   $
 Type��6�   $ False��6�   $ False��6�   $ False��6�      SelectedValueBinding 6}   �� *Type+ 5P      �� 5Q      "  6$   .�5R   "   ��  � ��
 �����5S   !   5T      5V      5X      5Y      �� 5[   
   $��Right=�6   $��Center=�61     �� Orientation$  
Horizontal=�6L   $��4��6e   $��1��6r   .+�5\      �� -   5        ! ��Name$! CancelButton��5\      $��Right=�6+   $��Center=�6G   $��15q�6b   $��Roboto Mono Medium)�6n   $��14(�6�   $
��Bold"�6�    ? ;MahApps.Brushes.Button.CleanWindow.Close.Background.Pressed#���  6�   ���	#FFF5C8C8$��	20,5,20,5q�6   $��Cancel��64  �� 5]      -	   5        $! SubmitButton��5]      $��Right=�6+   $��Center=�6G   $��15q�6b   $��Roboto Mono Medium)�6n   $��14(�6�   $
��Bold"�6�   ���	#FF264E21���	#FFC9E2B1���	#FF6B9263$��	20,5,20,5q�6�   $��Italic$�6  $��Submit��6  5^      �� 5_   
   $��3��6   $��1��6"   $��10q�62   .+�5`        -
   5        $
 dataGridPreview��5`      5a      5b      5c      