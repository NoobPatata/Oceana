   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5          Oceana__WPF_.UserInfo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Medium"�5
        MaterialDesignPaper#���  5      $��14(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      $��16(�5      $	��400��6   $	��650��6(   .��5      � .+�5   
   �� .+�5      �� $
��0,15q�6    $  MaterialDesignHeadline6TextBlock#��[ 6&   $��User Details��6`   $	��Top=�6t    �� TextAlignment$ Center=�6�   �� 5      $
��25,5q�6   $��User ID��6"   �� 5      -   5         ��Name$ 	txtUserId��5   T    �� 
IsReadOnly . $
��25,5q�6F   ��6)   �� *Info.UserID+6i   �� 5      $
��25,5q�6   $��	Firstname��6"   �� 5      -   5        $ txtFirstname��5   ^   $
��25,5q�6P   ��6   �� *FN+ �� UpdateSourceTrigger$ PropertyChanged=�6v   �� 5      $
��25,5q�6   $��Lastname��6"   �� 5      -   5        $ txtLastname��5   ]   $
��25,5q�6O   ��6   �� *LN+$ PropertyChanged=�6t   �� 5      $
��25,5q�6   $��Username��6"   �� 5      -   5        $ txtUsername��5   ]   $
��25,5q�6O   ��6   �� *UN+$ PropertyChanged=�6t   �� 5      $
��25,5q�6   $��Password��6"   �� 5      -   5        $ txtPassword��5   ]   $
��25,5q�6O   ��6   �� *PS+$ PropertyChanged=�6t   �� 5      $
��25,5q�6   $��Email��6"   �� 5       -   5        $ txtEmail��5    ]   $
��25,5q�6O   ��6   �� *EM+$ PropertyChanged=�6q   �� 5!      $
��25,5q�6   $��	UserGroup��6"   �� 5"      -   5         ��Name$ cbbUserGroup��5"   q    �� 
IsReadOnly . {�.  $
��25,5q�6c    �� SelectedItem 6;   �� *Info.UserGroup+5#      �� 5$      $��0,5,0,10q�6   	 �� Orientation$	 
Horizontal=�6,   $��Center=�6E   .+�5%      �� )  #MaterialDesignThemes.Wpf.DialogHost
   CloseDialogCommand#��Z
 6?   $
��True��6�   $��80��6�   $��40��6�   $
��25,5q�6�   $
��Save��6�   {�6   �� *AllFieldsFilled+6�   �� 5&      #��Z
 6   $��False��6\   $��80��6u   $��40��6�   $
��25,5q�6�   $��Cancel��6�   5'      5(      5)      5*      