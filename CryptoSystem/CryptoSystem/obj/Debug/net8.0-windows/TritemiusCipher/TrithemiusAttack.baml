   M S B A M L   `   `   `  ����G  CCryptoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CryptoSystem.TritemiusCipherCryptoSystem.TritemiusCipher  5   	   3    -CryptoSystem.TritemiusCipher.TrithemiusAttack   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:CryptoSystem.TritemiusCipher     5   	     � Title$  Attack��5      $	��364��6   $	��605��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ NoCiepherBox��5
      $
��Left=�6(    �� TextWrapping$
 Wrap=�6C   $��TextBox��6W   $	��Top=�6f   $	��290��6~   $��56��6�   ���	#FF252323���	#FFFDFDFD$��Italic$�6�   $��	22,94,0,0q�6�   ��6�   Z� 6�   �� 5   
   $H��BПроведення атаки на шифр Трітеміуса��6   $��Center=�6>   $	��Top=�6[   $��22(�6s   $
��Bold"�6�   �� 5   
   -   5        $��АТАКУВАТИ !��5      $
��Left=�6'   $��366,272,0,0q�6B   $	��Top=�6W   $	��162��6o   $��36��6{   
���  �����	#FFFFFEFE$��15(�6�   $
��Bold"�6�   ��6�   Z� 6�   �� 5   
   $9��3Незашифроване повідомлення��6   $
��Left=�65   $��	22,64,0,0q�6P   $	��Top=�6c   $��14(�6{   $
��Bold"�6�   $��40��6�   $	��314��6�   �� 5   
   -   5        $ 
CiepherBox��5      $
��Left=�6&   $
 Wrap=�6A   $��TextBox��6U   $	��Top=�6d   $	��290��6|   $��56��6�   ���	#FF252323���	#FFFDFDFD$��Italic$�6�   $��
22,196,0,0q�6�   ��6�   Z� 6�   �� 5   
   $5��/Зашифроване повідомлення��6   $
��Left=�63   $��
22,168,0,0q�6N   $	��Top=�6b   $��14(�6z   $
��Bold"�6�   $��40��6�   $	��314��6�   �� 5   
   $R��LВиберіть ймовірний спосіб задання ключа :��6   $
��Left=�6D   $��348,137,0,0q�6_   $	��Top=�6t   
���  ��$
��Bold"�6�   �� 5   
   -   5         ��Name$ ComboBox��5      $
��Left=�6%   $��370,168,0,0q�6@   $	��Top=�6U   $	��154��6m   $��28��6y   .@�5      �� $%��2-вимірний вектор��6   �� 5      $%��3-вимірний вектор��6   �� 5      $��
гасло��6   5      	� 5   
   -   5         	�Name$ UK��5      $#��Українська мова��6"   $
��Left=�6<   $��
412,84,0,0q�6W   $	��Top=�6k   $
��Bold"�6�   ���	#FF1009096�   	� 5   
   -   5        $ EN��5      $#��Англійська мова��6"   $
��Left=�6<   $��412,107,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   ���	#FF1009096�   5      5      