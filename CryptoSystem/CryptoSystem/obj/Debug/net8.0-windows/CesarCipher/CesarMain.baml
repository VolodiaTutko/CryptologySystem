   M S B A M L   `   `   `  ����G  CCryptoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CryptoSystem.CesarCipherCryptoSystem.CesarCipher  5   	   (    "CryptoSystem.CesarCipher.CesarMain   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CryptoSystem.CesarCipher     5   	     � Title$  CryptoSystem #1��5   
   $	��450��6"   $	��814��6/   ���	#FFB9B9B9 � 	Resources 5	         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� 5
   
   " ��6+   .�5      ��  � �� �#007acc6+   �� 5       � ��
 �����6+   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 15��5      ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver$
	 True��6=   . �5   "   ��  � �� �#005a8c6?   5      5      5      5      5       .��5!      � .+�5"   
   	� -   5        
 	�Name$
 UK��5"      $#��Українська мова��6"   $
��Left=�6<   $��670,118,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   
�������6�   	� 5#   
   -   5        $
 EN��5#      $#��Англійська мова��6"   $
��Left=�6<   $��670,139,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   
�������6�   �� 5$   
   -   5         ��Name$ textBoxForCipher��5$      $
��Left=�6,   $��	70,88,0,0q�6G    �� TextWrapping$
 Wrap=�6Z   $��Текст...��6n   $	��Top=�6~   $	��318��6�   $	��102��6�    J� RenderTransformOrigin$	 1,0&�6�   �� 5%   
   -   5        $ textBoxForDeCipher��5%      $
��Left=�6.   $��
70,252,0,0q�6I   $
 Wrap=�6]   $��Текст...��6q   $	��Top=�6�   $	��318��6�   $	��102��6�    �� 
IsReadOnly$
 True��6�   o� 5&   
   $��	0,0,0,385q�6   .@�5'      m� $��Файл��6   .@�5(      m� -   5        $��Створити��5(      6-   m� 5)      -   5        $��Відкрити��5)      6-   m� 5*      -   5        $��Зберегти��5*      6-   m� 5+      -   5        $��Друкувати��5+      6.   �� 5,      m� 5-      -	   5        $!��Про розробника��5-      63   m� 5.      -
   5        $��
Вихід��5.      6*   5/      50      �� 51   
   $��Вхідні дані: ��6   $
��Left=�6(   $��	70,54,0,0q�6C   $	��Top=�6V   
�������$��20(�6�   $��Yu Gothic UI)�6�   �� 52   
   $��Вихідні дані��6   $
��Left=�6'   $��
70,217,0,0q�6B   $	��Top=�6V   
�������$��20(�6�   $��Microsoft JhengHei Light)�6�   �� 53   
   -   5        $��Зашифрувати��53      $
��Left=�6'   $��413,145,0,0q�6B   $	��Top=�6W   $��32��6o   $	��102��6{   #��[  6�   ���	#FF000204$
��Bold"�6�   6�   �� 54   
   -   5        $��Розшифрувати��54      $
��Left=�6(   $��532,146,0,0q�6C   $	��Top=�6X   $��32��6p   $	��102��6|   #��[  6�   ���	#FF000102$
��Bold"�6�   $ 0.545,-1.131&�6�   6  �� 55   
   $0��*Введіть ключ для зсуву:��6   $
��Left=�62   $��
413,65,0,0q�6M   $	��Top=�6a   �� 56   
   -   5        $ keyBox��56      $
��Left=�6"   $��
418,96,0,0q�6=   $
 Wrap=�6Q   $��0��6e   $	��Top=�6n   $��97��6�    �� TextAlignment$ Center=�6�   $��20��6�   �� 57   
   -   5        $��Зберегти як��57      $
��Left=�6'   $��
70,359,0,0q�6B   $	��Top=�6V   $	��318��6n   $��24��6z   6�   �� 58   
   -   5        $[��UПобудувати частотну таблицю для вхідних даних��58      $
��Left=�6I   $��413,252,0,0q�6d   $	��Top=�6y   $��34��6�   $	��340��6�   ���	#FF0080FF$
��Bold"�6�   ���	#FFEDDFDF��6  Z� �� 59   
   -   5        $]��WПобудувати частотну таблицю для вихідних даних��59      $
��Left=�6J   $��413,291,0,0q�6e   $	��Top=�6z   $	��340��6�   $��34��6�   ���	#FF0080FF$
��Bold"�6�   ���	#FFEDDFDF��6
  Z� �� 5:   
   -   5        $*��$Організувати атаку ��5:      $
��Left=�6/   $��482,331,0,0q�6J   $	��Top=�6_   $��46��6x   $	��246��6�   #��[  6�   ���	#FFD80B0B$
��Bold"�6�   6�   �� 5;   
   -   5        $
��Left=�5;      $��
677,65,0,0q�6-   $	��Top=�6A   $��32��6Y   $	��102��6e   #��[  6q   ���	#FF000102$
��Bold"�6�   $ 0.545,-1.131&�6�   .��5<      ��  �� Orientation$ 
Horizontal=�6   .+�5=      �� $��./premium-icons.png��6   $��16��65   $��16��6@   �� 5>      $��5,0,0,0q�6   Преміум66   5?      5@      5B      5C      