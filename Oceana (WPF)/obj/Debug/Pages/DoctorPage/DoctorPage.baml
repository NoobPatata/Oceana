   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5   	       Oceana__WPF_.DoctorPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Oceana__WPF_     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Doctor Console��5	   	   $	��800��6    $
��1500��6-    � WindowStartupLocation$ CenterScreen=�6;    � WindowState$ 	Maximized=�6`    � Icon$ /Resources/oceanalogo.ico��6x   .��5      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
MainDialog��6    .��5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��8* �6#    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $��9* �6!   .+�5      � ���#64B5F6.+�5      �� $!��/Resources/No Klinik(2).png��6   $��
0,-3,2,3.4q�6?   5      �� 5       $��1��6   ���#1565C0.+�5"      �� -   5         ��Name$ ListViewMenu��5"      .@�5%      �� -   5         ��Name$ Patient��5%   #   ���#1565C0$��60��6I   $��1��6U   .��5&      �� 	 �� Orientation$	 
Horizontal=�6%   .+�5'      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Person=�66   
�������$��20��6W   $��20��6c   $��Center=�6n   $
��10,0q�6�   �� 5(      $��1��6(   $��PATIENT��68   $��Center=�6G   
�������$��15(�6u   $
��Bold"�6�   $	��5,0q�6�   5)      5*      5-      5.      � 50      $��1��6   .+�51      (  "MaterialDesignThemes.Wpf.ColorZone  ���#64B5F6$��80��6A   $��12q�6M   $��Center=�6Z   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�52   +   .��53      �  54      �� 55      $��* �6/   �� 56      $
��AUTO �6/   .+�5;      �� $	 
Horizontal=�6%   .+�5<      �� $��WELCOME DR.��6$   $��35(�6;   
�������$��5,0,0,0q�6]   $��Center=�6n   �� 5=      -   5         ��Name$ 
lblWelcome��5=   `   $��35(�6$   
�������$��Center=�6E   6`   �� 5>      $��!��6$   $��35(�61   
�������$��Center=�6R   5?      �� 5A      $��1��6%   $	 
Horizontal=�65   .+�5D      �� -   5         ��Name$ 
btnSetting��5D   %    0  ,MaterialDesignFloatingActionMiniAccentButton#��[  5E       � ToolTip$ User Profile��5F      .��5G   "     $

 Gear=�5H   %   $��24��5I   %   $��24��5J   %   5K      �� 5O      -   5        $ 
btnSignOut��5O   %   $
��20,0q�69   $	��150��6H   $��34��6T    $  MaterialDesignRaisedAccentButton#��[ 5P      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5Q   !   .��5S   "   �� $	 
Horizontal=�6-   .+�5T   &     $
 SignOut=�6>   $��26��6M   $��26��6Y   $��Center=�6d   �� 5U   &   $��SIGN OUT��60   $��Center=�6@   $��5q�6[   $��15(�6f   5V   #   5X      5Z      5[      5\      5]      � 5_      -   5         �Name$ GridMain��5_      $��1��6%   $��1��62   '  !MaterialDesignThemes.Wpf.Snackbar  5a      -   5          Name$ 
MySnackbar��5a   D   $��1��6&   $��2��66      MessageQueue 6X   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5c      5e      5g      