   M S B A M L   `   `   `  ����E  Aprevactndc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:prevactndc
prevactndc  5          prevactndc.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546fFluenturn:fluent-ribbon  5      $localclr-namespace:prevactndc  5        � Title$  PREVACT ndc��5	      $	��450��6-   $	��800��6:    � 	Resources 5
         MyBrush �� Color �� 
TargetType  PageBackground �� Property �� Value��%�   &	        &	      �� 5   
   $
 Gold��6*   �� 5   
   " ��6   .�5      ��  � ��
 ��  �6,   �� 5       � ��$ 5q�60   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5 �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��3��6!   $��False��65   .+�5        Fluent.Ribbon  $	��Top=�6      Menu 5         Fluent.Backstage  5!      5"      	   Tabs.	 5&        Fluent.RibbonTabItem  
   Header$

 Home��6'      Groups. 5'        Fluent.RibbonGroupBox  $��Group��6,   .@�5)        Fluent.Button     Header$	 Run��6(      Icon$  /icons/whirlwind_38011.ico��65      	LargeIcon$  /icons/whirlwind_38011.ico��6W     5*      $ Runs settings��6(   $ /icons/runsettings.ico��6?   $ /icons/runsettings.ico��6]   5+      5,      5-      5.      ]� 50   
   $��1��6   .+�51      R� $
��Left=�6   52      53      �� 55   
   $��1��6   $��1��6$   $��5��64   $��Stretch=�6>   ]� 57   
   $��1��6   $��2��6!   .+�58      &   System.Windows.Controls.DataGrid  $��Right=�6   59      5:      ]� 5<   
   $��2��6   $��3��6!   .+�5=      �� $��Bottom=�6   .@�5>      �� .��5?      �� -   5        $��lblCursorPosition��5?       5@      5A      5B      5D      5E      