   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	       Oceana__WPF_.AdminPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Oceana__WPF_     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5	   	     � Title$  Admin Console��5
   	   $	��800��6   $
��1500��6,   $	��800��69   $
��1500��6I    � WindowStartupLocation$ CenterScreen=�6Z    � WindowState$ 	Maximized=�6    � Icon$ /Resources/oceanalogo.ico��6�    � 	Resources 5         Oceana__WPF_.ObserveUser 	  users  cvsUsers �� Source(  "Oceana__WPF_.PasswordTextConverter  PasswordTextConverter��%r   &	        &	      7   &	 =       5   
   6   �� 5   
   -   5        8   5        5   
   6&   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
RootDialog��6       DialogContent 5   
   � 5      -   5        $��MultiDeleteDialogBox��5   2   $	��800��6   
�������.+�5      �� .+�5      ��  �� TextAlignment$ Center=�6       MaterialDesignBody1TextBlock#��[ 67   $=��7Are you sure you want to delete
the users listed below?��5      $��10q�6X   $	��Top=�6d   &   System.Windows.Controls.DataGrid  5      -   5        	  Name$	 dgDialogBoxUsers��5   ?   $	��600��6   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6/      CanUserSortColumns .    SelectionMode$ Single=�5         CanUserAddRows .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 13 8 8 8q�5         ColumnHeaderPadding$ 8q�5       $��14(�5!         
IsReadOnly . $
��10,0q�5"   V   $��80��6d   $��Center=�6s   ��6   �� *SelectedItems+ �� ElementName$ dgUsers��   ColumnHeaderStyle 5#      �� 5$       & "MaterialDesignDataGridColumnHeader �� BasedOn# [ 6$    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6b   .�5%   "   ��  �� Property � �� �� Value$ 16(�6=   �� 5&   "    � �� �#E8E8E86?   5'         Columns 5)      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5*      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ UserID��6[      	MaxLength$	 255��6k   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6@   �� *UserID+6k     5+      $
 Name��6]   $	 255��6k    6@   �� *
Fullname+6k     5,      $ Email��6Z   $	 255��6i    6@   �� *Email+6i     5-      $ 
User Group��6^   $	 255��6r    6@   �� *	UserGroup+6r   5/      �� 50       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Bottom=�6W   $
��0,10q�6r   .+�51      �� $	��5,0q�6!      CloseDialogCommand#��Z 6.   $	��Yes��6p   $��75��6~   $��35��6�   ��52      ��53   "   True��55   #   57      �� 58      $	��5,0q�6!   #��Z 6.   $��No��6p   $��75��6}   $��35��6�   ��59      ��5:   "   	False��5<   #   5>      5?      5@      5A      .��5D   
   �  � ColumnDefinitions 5F      �� 5G      $��2* �6#   �� 5H      $��8* �6#    � RowDefinitions 5J      �� 5K      $��1* �6    �� 5L      $��9* �6!   .+�5O      � ���#64B5F6.+�5P      �� $!��/Resources/No Klinik(2).png��6   $��
0,-3,2,3.4q�6?   5Q      �� 5T      $��1��6   ���#1565C0.+�5V      �� .@�5X      �� ���#1565C0$��60��69   $��0��6E   .��5Y      �� $ 
Horizontal=�6%   .+�5Z      '  !MaterialDesignThemes.Wpf.PackIcon      Kind$  ViewDashboard=�66   
�������$��20��6^   $��20��6j   $��Center=�6u   $
��10,0q�6�   �� 5[      $��1��6(   $��	DASHBOARD��68   $��Center=�6I   
�������$��15(�6w   $
��Bold"�6�   $	��5,0q�6�   5\      5]      5^      5b      � 5d      $��1��6   .+�5e      (  "MaterialDesignThemes.Wpf.ColorZone  ���#64B5F6$��80��6A   $��12q�6M   $��Center=�6Z   +  %MaterialDesignThemes.Wpf.ShadowAssist!   ShadowDepth$! Depth3=�5f   +   .��5g      �  5h      �� 5i      $��* �6/   �� 5j      $
��AUTO �6/   .+�5o      �� $��WELCOME ADMIN��6    $��35(�69   
�������$��5,0,0,0q�6[   $��Center=�6l   �� 5r      -   5        " ��Name$" 
btnSignOut��5r   !   $
��20,0q�65   $	��150��6D   $��34��6P   $��1��6\    $  MaterialDesignRaisedAccentButton#��[ 5s      +  %MaterialDesignThemes.Wpf.ButtonAssist#   CornerRadius$# 10��5t   !   .��5u      �� $ 
Horizontal=�6)   .+�5v   "     $  SignOut=�6:   $��26��6I   $��26��6U   $��Center=�6`   �� 5w   "   $��SIGN OUT��6,   $��Center=�6<   $��5q�6W   $��15(�6b   5x      5{      5}      5~      5      � 5�      $��1��6   $��1��6     5�      �� 5�      $��1* �6    �� 5�      $��4* �6    .+�5�      � .+�5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      �� -   5        $" btnAdd��5�      $
��20,0q�6-    $  MaterialDesignFlatAccentBgButton#��[ 6;   $# 5��6u   $��Center=�6�   .��5�      �  5�      �� 5�   "   $��1* �63   �� 5�   "   $��4* �63   .+�5�        $	��5,0q�66   $  	PersonAdd=�6C   $��25��6T   $��25��6_   $��Center=�6k   �� 5�      $��1��6(   $	��5,0q�68   $��ADD USER��6E   $��Center=�6U   $��20��6p   $
��Bold"�6|   5�      5�      �� 5�      -   5        $" 	btnRemove��5�      $
��20,0q�60   #��[ 6>   $# 5��6x   $��Center=�6�   .��5�      �  5�      �� 5�   "   $��1* �63   �� 5�   "   $��4* �63   .+�5�        $	��5,0q�66   $  PersonRemove=�6C   $��25��6W   $��25��6b   $��Center=�6n   �� 5�      $��1��6(   $	��5,0q�68   $��REMOVE USER��6E   $��Center=�6X   $��20��6s   $
��Bold"�6   5�      5�      �� 5�      -   5        $" btnEdit��5�      $
��20,0q�6.   #��[ 6<   $# 5��6v   $��Center=�6�   .��5�      �  5�      �� 5�   "   $��1* �63   �� 5�   "   $��4* �63   .+�5�        $	��5,0q�66   $  
PersonEdit=�6C   $��25��6U   $��25��6`   $��Center=�6l   �� 5�      $��1��6(   $	��5,0q�68   $��	EDIT USER��6E   $��Center=�6V   $��20��6q   $
��Bold"�6}   5�      5�      �� 5�      -   5        $" 
btnRefresh��5�      $
��20,0q�61   #��[ 6?   $# 5��6y   $��Center=�6�   .��5�      �  5�      �� 5�   "   $��1* �63   �� 5�   "   $��4* �63   .+�5�        $	��5,0q�66   $  Reload=�6C   $��25��6Q   $��25��6\   $��Center=�6h   �� 5�      $��1��6(   $	��5,0q�68   $��REFRESH LIST��6E   $��Center=�6Y   $��20��6t   $
��Bold"�6�   5�      5�      � 5�       5�      �� 5�      $
��AUTO �6/   �� 5�      $��* �6/   �� 5�      $
��AUTO �6/    5�      �� 5�      $��* �6,   �� 5�      $
��AUTO �6,   �� 5�      $��* �6,   .+�5�      �� $ 
Horizontal=�6%   $��1��6>   $��1��6K   $
��20,0q�6[   .+�5�        $��1��66   $  Search=�6D   $��30��6R   $��30��6]   $��	15,0,10,0q�6i   $��Center=�6|   �� 5�      -	   5        $ ��Name$$ 	txtSearch��5�   &   $��1��69   $��1��6F   $	��250��6V   )  #MaterialDesignThemes.Wpf.HintAssist%   Hint$% SEARCH��6b   $��15(�6�   5�      5�      5�      5�      #  MaterialDesignThemes.Wpf.Card  5�      ���#ECEFF1$��
10,0,10,10q�67   &   UniformCornerRadius$& 10Q�6K   $��1��6e   .��5�        -
   5        $	 dgUsers��5�   +   $
 * 6    . $ Extended=�5�       .  '   CanUserReorderColumns' .   .  $ 13 8 8 8q�5�      $ 8q�5�      $��18(�5�       . ��5�      �� ( �� Source#( [  5�      �� 5�      # [ 6    "  6^   .�5�      ��  � ��$ 18(�69   �� 5�       � �� �#ECEFF16;   5�       5�        5�      $ UserID��5�      $	 255��5�      ) 	  Width$	) 150 6-    5�      �� *UserID+5�   -     5�      $ 	Full Name��5�      $	 255��5�       5�      �� *
Fullname+5�        5�      $ Username��5�      $	 255��5�       5�      �� *
Username+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ Password��65   *   CellTemplate* 5�   "   �� 5�   &   .R�5�   *   �� ��60   �� *
Password++ �� 	Converter#+ [ 5   '   5       5     $ Email��5     $	 255��5      5     �� *Email+5       5     $ 
User Group��5     $	 255��5
      5	     �� *	UserGroup+5
     5     5     5     '  !MaterialDesignThemes.Wpf.Snackbar  5     -   5        ,  Name$, 
MySnackbar��5  D   $��1��6&   $��2��66   -   MessageQueue- 6X   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5     5     5     