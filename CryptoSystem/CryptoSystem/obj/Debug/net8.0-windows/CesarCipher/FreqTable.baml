   M S B A M L   `   `   `  ����G  CCryptoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CryptoSystem.CesarCipherCryptoSystem.CesarCipher  5   	   (    "CryptoSystem.CesarCipher.FreqTable   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:CryptoSystem.CesarCipher     5   	     � Title$  	FreqTable��5   	   $	��450��6   $	��525��6(   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ frequencyDataGrid��5
         AutoGenerateColumns$ False��6.      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Symbol��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Symbol+6P     5      $ 	Frequency��6%   $ * 6V    68   �� *	Frequency+6V      ColumnHeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      �� 	 �� Property	 � ��
 �� Value
 �	#FF1C1C1C63   �� 5      	 � ��

 �����63   �� 5      	 � ��

 �   �64   �� 5      	 � ��$
 0,1,1,1q�68   �� 5      	 � ��$
 5q�60   5         RowStyle 5      �� 5      )  #System.Windows.Controls.DataGridRow"  6   .�5      �� 	 � ��
 �	#FF2B2B2B63   �� 5      	 � ��

 �����63   �� 5      	 � ��

 �   �64   �� 5      	 � ��$
 0,0,1,1q�68   �� 5      	 � ��$
 30��6/   5         	CellStyle 5!      �� 5"      *  $System.Windows.Controls.DataGridCell"  6   .�5#      �� 	 � ��

 �   �64   �� 5$      	 � ��$
 0,0,1,1q�68   �� 5%      	 � ��$
 5q�60   5&      5(      5)      5*      