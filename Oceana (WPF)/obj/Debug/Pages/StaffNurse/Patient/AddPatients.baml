   M S B A M L   `   `   `  ����G  COceana (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Oceana__WPF_Oceana__WPF_  5          Oceana__WPF_.AddPatients   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Oceana__WPF_     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Medium"�5
        MaterialDesignPaper#���  5      $��14(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      $��16(�5      $	��800��6   $	��600��6(   .��5      �  � RowDefinitions 5   
   �� 5      $
��AUTO �6   �� 5      $��* �6   .+�5   
   ��  $  MaterialDesignHeadline5TextBlock#��[ 6   $��Add Patients��5      $��Center=�5      $��0,10,0,0q�5      $��1��5      � 5   
   $��1��6   $��2��6    5       �� 5!      $
��3.5* �6    �� 5"      $��1* �6    .+�5%      �  � ColumnDefinitions 5&      �� 5'      $��1* �6'   �� 5(      $��1* �6'    5+      �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   .+�57      �� $��Basic Information��6   $
��20,5q�58      $��	Underline{�6*   �� 5;      $��1��6   .+�5<      �� -   5         ��Name$ txtFirstName��5<   d   $��0��6    % !MaterialDesignFloatingHintTextBox#��[ 5=      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
First Name��5>      $
��20,5q�5?      ��5<   +   �� *FN+ �� UpdateSourceTrigger$ PropertyChanged=�5?      �� 5@      -   5        $ txtIC��5@   d   $��2��6   #��[ 5A      $ Identification Number��5B      $
��20,5q�5C      ��5@   +   �� *ID+$ PropertyChanged=�5C      5D      �� 5G      $��1��6   $��1��6-   .+�5H      �� -   5        $ txtLastName��5H   d   $��1��6   #��[ 5I      $ 	Last Name��5J      $
��20,5q�5K      ��5H   +   �� *LN+$ PropertyChanged=�5K      5L      �� 5O      $��2��6   $��Contact Information��6)   $��	20,10,0,5q�5P      $��	Underline{�6/   �� 5S      $��3��6   .+�5T      �� -   5        $ txtPhone��5T   d   $��3��6   #��[ 5U      $ Phone Number��5V      $
��20,5q�5W       �� 	MaxLength$ 11��5X      ��5T   +   �� *CN+$ PropertyChanged=�5X      �� 5Z      $��3��6"   .+�5[      �� -   5        $ 
txtAddress��5[   h   $��5��6"   #��[ 5\      $ Address��5]      $
��20,5q�5^       �� TextWrapping$
 Wrap=�5_      ��5[   /   �� *AD+$ PropertyChanged=�5_      5`      5a      �� 5d      $��1��6   $��3��6-   .+�5e      �� -   5        $ txtEmail��5e   e   $��4��6   #��[ 5f      $ Email��5g      $
��20,5q�5h      ��5e   ,   �� *EM+$ PropertyChanged=�5h      5i      �� 5l      $��4��6   $��Basic Health Information��6)   $��	20,10,0,5q�5m      $��	Underline{�6/   �� 5p      $��5��6   .+�5q      �� -   5        $ 	txtHeight��5q   d   $��6��6   #��[ 5r      $ Height��5s      $
��20,5q�5t      ��5q   +   �� *CM+$ PropertyChanged=�5t      �� 5u      -   5        $ txtAllergies��5u   e   $��8��6   #��[ 5v      $ 	Allergies��5w      $
��20,5q�5x      ��5u   ,   �� *AL+$ PropertyChanged=�5x      5y      �� 5|      $��1��6   $��5��6-   .+�5}      �� -	   5        $ 	txtWeight��5}   d   $��7��6   #��[ 5~      $ Weight��5      $
��20,5q�5�      ��5}   +   �� *KG+$ PropertyChanged=�5�      �� 5�      -
   5        	 ��Name$	 cbbBloodType��5�   n   $��9��6    & "MaterialDesignFloatingHintComboBox#��[ 5�      $ 	BloodType��5�      $
��20,5q�5�      
 �� SelectedItem
 5�   -   �� *BT+$ PropertyChanged=�5�      5�      5�      �� 5�      $��1��6   $��Center=�6&   $��Center=�6B    �� Orientation$ 
Horizontal=�5�      .+�5�      �� $��10��6?   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6M   $
��True��6�   $��80��6�   $��40��6�   $
��25,5q�6�   $	��Add��6�   {�6   �� *AllFieldsFilled+6�   �� 5�      $��11��6   #��Z 6'   $��False��6i   $��80��6�   $��40��6�   $
��25,5q�6�   $��Discard��6�   5�      5�      5�      5�      