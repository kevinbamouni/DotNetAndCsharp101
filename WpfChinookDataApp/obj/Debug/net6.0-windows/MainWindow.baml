   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    WpfChinookDataApp"   WpfChinookDataApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.33.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  	HATARI PC��5   	   $	��450��6   $	��800��6(    � Icon$ /icons/hatari_pc.png��64      backgroundcolor#��[  6P   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��5 �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��3��6!   $��False��65   .+�5      o� $	��Top=�6   #��[  6(   .@�5      m� $��_FileAlmost��6     MenuItemStyle#���  61   5      m� 5      $��_Tools��6   #���  6+   5      5      `� 5      $	��Top=�6   .�5       c� .@�5!      �� -   5        $��5q�5!      .��5"      ��  �� Orientation$ 
Horizontal=�6%   .+�5#      �� $ ��/icons/whirlwind_38011.ico��6$   $��20��6H   $��20��6S   5$      5%      �� 5&      -   5        $��5q�5&      .��5'      �� $ 
Horizontal=�6%   .+�5(      �� $��/icons/copy-solid.png��6$   $��20��6C   $��20��6N   5)      5*      �� 5+      -   5        $��5q�5+      .��5,      �� $ 
Horizontal=�6%   .+�5-      �� $!��/icons/file-excel-solid.png��6$   $��20��6I   $��20��6T   5.      5/      �� 50      -   5        $��5q�50      .��51      �� $ 
Horizontal=�6%   .+�52      �� $"��/icons/floppy-disk-solid.png��6$   $��20��6J   $��20��6U   53      54      55      c� 56      .@�57      �� $	��Cut��6   $	��Cut��6+   �� 58      $
��Copy��6   $
��Copy��6,   �� 59      $��Paste��6   $��Paste��6-   5:      5;      5<      ]� 5@   
   $��1��6   #��[  6!   .+�5A      � $��10q�6    5B      �� 5C      $
��Auto �6$   �� 5D      $
��Auto �6$   .+�5F      �� 
���   �$��1q�6-   ]� 5G      $��0��6   #��[  6)   .+�5H      �� $
��Left=�6   $��Center=�67   .��6R   Navigation Pane6c   d� 5I      $��Right=�6#   $��Center=�6?   
�������.��5J      �� $ 
Horizontal=�6%   .+�5K      �� $%��/icons/arrows-up-down-solid.png��6$   $��10��6M   $��10��6X   $��Center=�6d   $��Center=�6�   5L      5M      5N      R� 5O      #��[  6   $��1��6I   .@�5P      Q� $��Level 1��6#    Q� 
IsExpanded$
 True��64   .@�5Q      Q� $��	Level 2.1��6'   $��fonts\RobotoMono-Bold.ttf)�6:   Q� 5R      $��	Level 2.2��6'   $
 True��6:   .@�5S      Q� $��	Level 3.1��6+   Q� 5T      $��	Level 3.2��6+   5U      Q� 5V      $��	Level 2.3��6'   5W      Q� 5X      $��Level 1��6#   $
 True��64   .@�5Y      Q� $��	Level 2.1��6'   Q� 5Z      $��	Level 2.2��6'   $
 True��6:   .@�5[      Q� $��	Level 3.1��6+   Q� 5\      $��	Level 3.2��6+   5]      Q� 5^      $��	Level 2.3��6'   5_      5`      5a      5b      �� 5f   
   $��1��6   $��1��6$   $��5��64   $��Stretch=�6>   ]� 5j   
   $��1��6   $��2��6!   .+�5k      �� -   5         ��Name$ 
tabControl��5k       �� TabStripPlacement$	 Top=�6-   .@�5l      �� $��
INPUT DATA��6     TabItemStyle1#��[ 6.   .��5m      � #��[  6    5n      �� 5o      $	��67* �6/   �� 5p      $
��195* �6/    5r      �� 5s      $
��Auto �6,   .+�5u      &   System.Windows.Controls.DataGrid  -   5          Name$ InputDataGrid��5u   #   $��0��6:   $��5,5,5,5q�6G   $��2��6�   5v      5w      �� 5x      $��PROGRAM��6   #��[ 6+   .��5y      � #��[  6    5z      �� 5{      $
��Auto �6,   5}      5~      �� 5      $��OUTPUT��6   #��[ 6*   .��5�      � #��[  6    5�      �� 5�      $��* �6,   �� 5�      $��* �6,   .+�5�        ScottPlot.WpfPlot  -   5        $��TestPlot��5�   "   $��0��62     5�      -   5        $��	TestPlot1��5�   "   $��1��63   5�      5�      �� 5�      $	��LOG��6   #��[ 6'   .��5�      � #��[  6    5�      �� 5�      $��* �6/    5�      �� 5�      $
��Auto �6,   .+�5�      �� -	   5        	 ��Name$	 LogTextBlock��5�   $   $��0��6:   $��14(�6G   $��consolas)�6U   $��Italic$�6k   $
��Wrap=�6~   $��5,5,5,5q�6�   
 �� Padding$
 5,5,5,5q�6�   ���#f5f6ff��Chaque action d'un système informatique (ouverture d'une session, installation d'un programme, navigation sur Internet...) produit un fichier log. Ces fichiers textes listent chronologiquement les évènements exécutés. Ils s'avèrent utiles pour comprendre la provenance d'une erreur en cas de bug. Ils permettent également d'établir des statistiques de connexions à un site Web ou à un serveur, grâce à des outils comme WebAlizer ou Webtrends. L'analyse des fichiers logs peut se faire manuellement, mais les logs ne sont pas aisés à déchiffrer, et les outils d'analyse fournissent la plupart des informations nécessaires.5�      5�      5�      5�      5�      ]� 5�   
   $��2��6   $��3��6!   $��False��65   .+�5�      �� $��Bottom=�6   .@�5�      �� .��5�      �� -
   5        $��lblCursorPosition��5�       5�      5�      5�      5�      5�      