   M S B A M L   `   `   `  ����B  >Lombard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lombard.WindowsLombard.Windows  5   	        Lombard.Windows.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lombard.Windows     5   	     � WindowStartupLocation$  CenterScreen=�5   E      base_window#��[  6j   $	��450��6�   $	��800��6�    � Title 6	   ��  �� ElementName$ 	MainFrame�� �� Path$ Content.Title�.��5	      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   �   
additional#��[ 6   �� 5   
   $��/Resources/493874.png��6   $��10q�6/   $
��Left=�6;   �� 5   
   $��0��6   $��ООО Ломбард��6!   $��Center=�64   $��Center=�6Q   #��[ 6l   $��20(�6�   $
��Bold"�6�    � 5   
   -   5          �Name$ 	MainFrame��5      $��1��6#    
 akcent#��[ 60     � NavigationUIVisibility$ Hidden=�6V   $��1q�6v   6�   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0 30 0 0q�6W   .+�5      �� -   5         ��Name$ 
BtnAvtoriz��5      $��
Выйти��6)   6T   �� 5      -   5        $ BtnEditGoods��5      $��Товары��6+   6Z   �� 5      -   5        $ BtnEditOrders��5      $��Заказы��6,   6[   �� 5      -   5        $ BtnBack��5      $��
Назад��6&   6N   5      �� 5    
   -   5        	 ��Name$	 TextBlockName��5       $
��auto��6+   $��40��68   $��Right=�6D   $	��Top=�6`   � 5!   
   $��2��6   #��[ 6   5"      5#      