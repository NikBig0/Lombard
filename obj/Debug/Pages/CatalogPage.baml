   M S B A M L   `   `   `  ����B  >Lombard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Lombard.PagesLombard.Pages  5          Lombard.Pages.CatalogPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Lombard.Pages     5      -   5          N� Title$  Каталог��5	         	base_page#��[  6A   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��Stretch=�6!     
additional#��[ 6?   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $O��IВведите наименование товара для поиска:��6     base_textblock#��[ 6K   �� 5      -   5         ��Name$ 
TBoxSearch��5   &   $	��275��6   6:   5      �� 5      $ 
Horizontal=�6   .+�5      �� $!��Сортировать по��6   #��[ 62   �� 5      -   5         ��Name$ 	ComboSort��5   '   $	��275��6   .@�5      �� $!��По возрастанию��6#   �� 5      $��По убыванию��6#   5       5!      5#      �� 5%   
   -   5         ��Name$ TextBlockCount��5%   !   $��1��6   $	��300��69   $
��Left=�6E   �� 5&   
   -   5        $ TextBlockBasketInfo��5&   !   $��1��6   $	��200��6>   $��Right=�6J   $��	0 0 140 0q�6f   �� 5'   
   -   5         ��Name$ 	BtnBasket��5'   X   $��1��6   $	��120��6   $��Right=�6*   $��Корзина��6F   6�   �� 5)   
   -   5         ��Name$ ListBoxProducts��5)      $��Visible=�6+    �� SelectedValuePath$ AgentId��6^   $��2��6z   $��0��6�     	good_item#��[ 6�   ��5+      �� 5-      .R�5/      � $��Stretch=�6   	 � UseLayoutRounding	 . 
 � ColumnDefinitions
 51      �� 52      $��60 �6/   �� 53      $��* �6/   �� 54      $��80 �6/   .+�57      �� $��0��6    $��60��60   $��40��6;   $��Uniform=�6G   $��5 0 5 0q�6z   ��6Y   ��  �� Path$ GetPhoto�6z   �� 58      $��1��6%   .+�59      �� $��2q�6(   $��16(�63   $
��Bold"�6A   $
��Auto��6s   $
��Left=�6�   ��6S   �� $ 	Item_Name�6�   �� 5:      $��2q�6(   $��16(�63   $
��Auto��6c   $
��Left=�6p   ��6A   �� $ Description�6p   �� 5;      $��2q�6(   $��16(�63   $
��Auto��6�   $
��Left=�6�   ��6A   �� $ 
Client.FIO� �� StringFormat$ Продавец: {0}��6�   �� 5<      $ 
Horizontal=�6)   .+�5=   "   �� $��2q�6,   $��16(�67   $
��Auto��6�   $
��Left=�6�   
���  ����6E   �� $ evaluation_cost�$ c�� �� ConverterCulture$ ru-RU��6�   5>      5?      �� 5@      $��80��6$   $��Center=�6/   $��2��6J   $��5q�6Z   $��26(�6e   ��6s   �� $ ProductDiscountAmount�$  {0} %��5B      5D       � ContextMenu 5H      �� 5I      .@�5K      m� -   5        $$��Добавить в заказ��5K      6R   5M      5S      5T      5U      