   M S B A M L   `   `   `  ����B  >Lombard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lombard.WindowsLombard.Windows  5   	   $    Lombard.Windows.NewOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lombard.Windows     5   	     � Title$'  !Оформление заказа��5   	      base_window#��[  6$   $	��500��6I   $	��600��6V   $	��400��6b   $	��400��6r    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �   
additional#��[ 6   $��2��68   �� 5   
   $��/Resources/493874.png��6   $��10q�6/   $
��Left=�6;   �� 5   
   $��0��6   $��ООО Ломбард��6!   $��2��64   $��Center=�6H   $��Center=�6e   #��[ 6�   $��20(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ TextBlockOrderNumber��5    *   $��Заказ №��5      $��1��6#   $��0��60   $��2��5       $��Center=�5!      $��Center=�5"      $��20(�5#      $
��Bold"�5$      �� 5%   
   $��Дата заказа��6   $��2��6'   $��0��64   $
��Left=�5&      $��60 0 0 0q�65   $��Center=�5'        item_textblock#��[ 5(      $
��Bold"�5)      �� 5*   
   -   5        $ TextBlockOrderCreateDate��5*      $��2��66   $��1��6C   $��Center=�5+      $
��Left=�61   #��[ 5,      $
��Bold"�5-      �� 5.   
   $��Покупатель��6   $��3��6&   $��0��63   $
��Left=�5/      $��60 0 0 0q�6-   $��Center=�50      #��[ 51      $
��Bold"�52      �� 53   
   -   5         ��Name$ CmbBuyer��53       �� SelectedItem$ Client��6%    �� DisplayMemberPath$	 FIO��6;    �� SelectedValuePath$ 	Client_ID��6S   $��1��6q   $��3��6�   6�   �� 5@   
   	 �� Orientation$	 
Horizontal=�6   $��6��6.   �� 5A   
   -   5        
 ��Name$
 ListBoxOrderProducts��5A      $��Visible=�60   $	 Key��6c   $��6��6|   $��0��6�   $��2��6�     	good_item#��[ 6�   ��5C      �� 5E      .R�5G      �  5I      �� 5J      $��60 �6/   �� 5K      $��* �6/   �� 5L      $��80 �6/   .+�5N      �� $��0��6    $��60��60   $��40��6;   $��Uniform=�5O   "   $��5 0 5 0q�5Q   "   ��5P   "   ��  �� Path$ Key.GetPhoto�5Q   "   �� 5S      $��1��6%   .+�5U      �� $��2q�6(   $��16(�63   $
��Auto��5W   *   $
��Left=�67   ��5V   *   �� $ Key.Item_Name�5W   7   �� 5X      $��2q�6(   $��14(�63   $
��Auto��5Z   *   $
��Left=�67   ��5Y   *   �� $ Key.Description�5Z   7   �� 5[      $��2q�6(   $��14(�63   $
��Auto��5]   *   $
��Left=�67   ��5\   *   �� $ Key.Client.FIO� �� StringFormat$ Продавец: {0}��5]   7   �� 5^      $	 
Horizontal=�6)   .+�5`   "   �� $��2q�6,   $��16(�67   $
��Auto��5b   .   $
��Left=�6;   
��� � ���5a   .   �� $ Key.evaluation_cost�$ c�� �� ConverterCulture$ ru-RU��5d   .   5f      �� 5h      $	 
Horizontal=�6)   .+�5j   "   �� $��14(�6,   $��количество:��6:   $
��Left=�6M   �� 5l   "   -   5        $��14(�5l   *   $��60��6Z   $
��Left=�6e   ��68   �� $ Value.Count�
 � Tag 6�   �� $	 Key�6�   5n      �� 5p      $��12(�6(   $
��Left=�6V   ��66   �� $ 	Key.Count�6V   �� 5r      $��16(�6(   $	��300��6{   $
��Left=�6�   ��66   �� $ Value.Total�$  итого: {0:F2} руб.��6�   5t      5y      5{      5      �� 5�   
   -   5        $ TextBlockTotalCost��5�      $��7��60   $��2��6=   �� 5�   
   $	 
Horizontal=�6   $��8��6.   $��2��6;   $��Center=�6O   .+�5�      �� -   5         ��Name$ BtnOk��5�   ?   $	��100��6   $��30��6!   $��Закрыть��6-   6N   �� 5�      -   5        $ 	BtnDelete��5�      $��Удалить��6(   $	��100��6S   �� 5�      -	   5        $ 
BtnBuyItem��5�      $��Оформить��6)   $	��100��6<   6H   5�      5�      5�      