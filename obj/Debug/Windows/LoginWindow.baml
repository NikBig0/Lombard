   M S B A M L   `   `   `  ����B  >Lombard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Lombard.WindowsLombard.Windows  5   	   !    Lombard.Windows.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Lombard.Windows     5   	     � Title$  Вход��5   	      base_window#��[  6   $	��350��6;   $	��400��6H   $	��200��6T   $	��400��6d    � WindowStartupLocation$ CenterScreen=�6s    � 
ResizeMode$ NoResize=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��34 �6   �� 5      $��34 �6   �� 5      -   5         ��Name$ RowCaptcha1��5      $��34 �61   �� 5      -   5        $ RowCaptcha2��5      �� 5      $��40 �6   .+�5   
   �   
additional#��[ 6   �� 5   
   $��/Resources/493874.png��6   $��10q�6/   $
��Left=�6;   �� 5   
   $��0��6   $��ООО Ломбард��6!   $��Center=�64   $��Center=�6Q   #��[ 6l   $��20(�6�   $
��Bold"�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      ��   item_textblock#��[ 6   $��1��6@   $��
Логин��6M   $
��20 0q�6Z   $��Center=�6h   $	��120��6�   �� 5      -   5         ��Name$ TbLogin��5      $��1��6'   $	��200��67   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   .+�5       �� #��[ 6   $��2��6@   $��0��6M   $��Пароль��6]   $
��20 0q�6k   $��Center=�6y   $	��120��6�   G� 5!      -   5         G�Name$ TbPass��5!      $��30��6*   $	��200��66   5"      �� 5#   
   $ 
Horizontal=�6   $��3��6.   .+�5$      �� #��[ 6   $��2��6@   $��0��6M   $��Введите капчу��6]   $
��20 0q�6r   $��Center=�6�   $	��120��6�   �� 5%      -   5        $ 	TbCaptcha��5%      $��1��6)   $	��200��69   5&      �� 5'   
   -   5        	 ��Name$	 ImageCaptcha��5'      $��4��6   $	��100��63   $	��300��6@   $	��Top=�6L   �� 5)   
   -   5        
 ��Name$
 BtnRenewCaptcha��5)   �   $��24��6   $��24��6   $��0q�6(   $	��Top=�64   $��O��6S   $
��Left=�6_   $	��Top=�6z   $��3��6�   �� 5*   
   $ 
Horizontal=�6   $��5��6.   $��Center=�6;   .+�5+      �� -   5        $
 BtnOk��5+   :   $	��100��6   $��30��6!   $��OK��6-   6I   �� 5,      -	   5        $
 	BtnCancel��5,   >   $	��100��6   $��30��6!   $��Cancel��6-   6Q   5.      �� 50   
   -
   5         ��Name$ TextBlockTime��50   I   #��[ 6   $��4��6<   $��Center=�6`   $��Bottom=�6}   $	��326��6�   52      53      