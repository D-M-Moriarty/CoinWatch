   M S B A M L   `   `   `  ����I  ECoinWatchViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CoinWatchViewsCoinWatchViews  5           CoinWatchViews.AddCoinView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:CoinWatchViews     5      .��5	      � -   5          �Name$  ExpenseGridPanel��5	      $��10q�6%    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Coin Name:��6   $��0��6%   �� 5   
   $��1��67   $�� 0 0 0 5q�6G   ��6   ��  �� Path$ Coin.COIN_NAME�6G   �� 5   
   -   5        $��1��5      $��0,4,0,-4q�6   .��6G   Save5      �� 5   
   -   5        $��1��5      $��1��6   $��Upload Image��5      $	��100��5      $��0 0 0 0q�6   �� 5   
   $��10q�6   $��2��6    $��1��6-   ��6=   �� $ FileName� �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�5"      5#      