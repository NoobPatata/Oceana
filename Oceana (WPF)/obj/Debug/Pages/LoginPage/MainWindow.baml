   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5   	       Oceana__WPF_.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Oceana__WPF_     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��700��6   $	��450��6$   $��Segoe UI Emoji)�5
   	    � WindowStartupLocation$ CenterScreen=�6%   $��20(�6J    � 
ResizeMode$ NoResize=�6X    � Icon$ /Resources/oceanalogo.ico��6o    � WindowStyle$
 None=�6�   ���#E3F2FD.��5      �  � RowDefinitions 5      �� 5      $
��350* �6    �� 5      $
��450* �6    .+�5   
   �� $(��"/Resources/LoginPageBackground.jpg��6   $��UniformToFill=�6<   $��0��6U   �� 5   
   $��/Resources/oceana.png��6   $��UniformToFill=�6/   $
��0,20q�6H   $��Center=�6V   $��Center=�6s   $	��400��6�   �� 5   
   -   5         &  "MaterialDesignFloatingActionButton#��[  5      $��Right=�6z   $��0,-10,-9.4,260.4q�6�   ��6M   Z� ��6c   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   
���  ��$��30��6D   $��30��6O   5      #  MaterialDesignThemes.Wpf.Card  5   
   $��10,200,10,0q�6   $	��400��63   $	��350��6@   $	��Top=�6L   $��2��6d      UniformCornerRadius$ 20Q�6u   .��5      � .+�5"      �� $��LOGIN��6   $��Center=�6,   $��10q�6I   $��30(�6V   �� 5%      $��Center=�6!   $��Center=�6>   .+�5(      ��  �� Orientation$ 
Horizontal=�6%   $��65��6>   .+�5)        $ Account=�66   $��Center=�6E   $��30��6`   $��30��6l   $��
5,31,5,3.8q�6w   �� 5*      -   5        	 ��Name$	 txtUsername��5*   &   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 USERNAME��6;    % !MaterialDesignFloatingHintTextBox#���  6e   $��15(�6�   $	��270��6�   $��40��6�   $��0��6�   $��0,21,0,0q�6�   5+      �� 5.      $ 
Horizontal=�6%   $��65��6>   .+�5/        $ TextboxPassword=�66   $��Center=�6M   $��30��6h   $��30��6t   $��5,36,5,-1.2q�6   G� 50      -   5         G�Name$ txtPassword��50   *   $
 PASSWORD��6?    ) %MaterialDesignFloatingHintPasswordBox#���  6i   $��15(�6�   $	��270��6�   $��4��6�   $��1��6�   51      �� 55      -   5         ��Name$ btnLogin��55   "   $��25,30q�64   $��20(�6D   $��45��6R   $��3��6^   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6k   .��56      �� $ 
Horizontal=�6)   $	��150��6B   $��40��6N   .+�57   "     $ SignIn=�6:   $��30��6H   $��25��6S   $��	20,5,0,10q�6_   �� 58   "   $��LOGIN��6(   $	��0,0q�68   
�������6E   59      5:      5=      5?      5@      '  !MaterialDesignThemes.Wpf.Snackbar  5C   
   -   5          Name$ 
MySnackbar��5C   "   $��1��6c   $��Stretch=�5D   "   $��Bottom=�6@   $��Center=�6[   $��	30,0,30,0q�6�      MessageQueue 5C   6   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5D   �   5F      5H      