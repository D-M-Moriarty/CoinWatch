   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      I ECoinWatchViews, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CoinWatchViewsCoinWatchViews 5          CoinWatchViews.CoinProfile   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .localclr-namespace:CoinWatchViews     5      ` \Xceed.Wpf.Toolkit, Version=2.9.15603.14400, Culture=neutral, PublicKeyToken=ba83ff368b7563c64xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5       
  Brush1 �� Color  PostListDataTemplate � ColumnDefinitions � RowDefinitions��%�  &	        &	 #     �� 5   
   $ 	#FFDDDDDD��6)   �� 5   
   .R�5      � $	��0,2q�6    5      �� 5      $��35 �6'   �� 5      $��* �6'   �� 5      $��* �6'    5      �� 5      $��25 �6$   �� 5      $��30 �6$   �� 5      $��30 �6$   .+�5      �� $��0��6   $��3��6*   .+�5      �� $��8(�6:   ��6!   �� *	USER_ID+6:   �� 5      $��8(�6;   ��6!   �� *
DATETIME+6;   5      �� 5      $��3��6   $��0��61   $��1��6A   $��8(�6g   ��6N   �� *	MESSAGE+6g   �� 5       $��2��6   $��0��6&   $��30��66   $��15��6A   $��Reply��6M   $��8(�6]   $��0 0 5 0q�6j   �� 5!      $��2��6   $��2��6&   $��30��66   $��15��6A   $
��Like��6M   $��8(�6\   $��0 0 35 0q�6i   �� 5"      $��2��6   $��2��6&   $��30��66   $��15��6A   $��Dislike��6M   $��8(�6_   $��35 0 0 0q�6l   5#      5$      5%      .��5'      � $��5q�6    5(   
   �� 5)      $��80 �6   �� 5*      $��* �6    5,   
   �� 5-      $	��110 �6   �� 5.      $��40 �6   �� 5/      $��* �6   .+�53   
   �� $��0��54      $��0��6    ��53      ��  �� Path$ 
Coin.IMAGE�54       �� 55   
   $��1��56      $��0��6!   $
��20 5q�57      ��55      �� $ Coin.COIN_NAME�57      �� 58   
   -   5        $��2��58      $��0��6   $��0,0,0,90q�59      $��20��6#   ��5:      �� $ FollowString� �� Mode$ TwoWay=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� UpdateSourceTrigger$ PropertyChanged=���5@      �� 5A      	 �� 
TargetType"	 ��6   .�5D      �� 
 �� Property
 � �� �� Value �	#FF0AC00A63    �� Triggers 5E      �� 5F       �� Binding 6&   �� *
IsFollowed+ �� Value True5G   &   .a�5H      �� 
 � �� �	#FFD439546;   5I      5K      5M      �� 5O   
   $��2��6   $��0��6!   $��
0,45,0,-40q�5Q      $��11(�6(   ��5P      �� $ PriceAlertSet�5Q   (   �� 5S   
   -   5        $��2��5S      $��0��6   $��	0,65,0,55q�5Y      $��20��6$   ��5T      �� $ IsGreaterThanString� .  . $ PropertyChanged=�5Y   $   %  Xceed.Wpf.Toolkit.DecimalUpDown  5[   
   -   5        $��MyUpDownControl��5\   0   $��2��5[      $��0��6*   $��	0,90,0,25q�5\      $��25��5]      ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Enter Price��5_      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5^      �� $ CoinValue.COIN_VALUE1�5_      �� 5a   
   -   5        $��2��5a      $��0��6   $��Set Price Alert��5b      $��	0,120,0,0q�5d      $��20��6$   �� 5g   
   $��0��6   $��1��5h      $��20��6$   $��	0 -90 0 0q�5i      �� 5j      $	�€��6    �� 5k      �6   �� $ CoinValue.COIN_VALUE1�5l      � 5o   
   $��0��6   $��1��6    5p      �� 5q      $
��Auto �6    60   �� 5r      $
��Auto �6    60   �� 5s      $��* �6    6-   .+�5v      #   LiveCharts.Wpf.CartesianChart  $��0 15 0 0q�6!   $��2��63   &    LiveCharts.Wpf.Charts.Base.Chart   Series 6@   �� $ SeriesCollection�   AxisX 5x         LiveCharts.Wpf.Axis     Labels 6   �� $ Labels�5z      5{      �� 5~   
   $��Trending Posts��6   $��10 0 0 0q�6*   $��1��5      $��1��6!   �� 5�   
   -   5        $��1��5�      $��1��6!   $��50��5�      $��20��6   $��150 -20 0 0q�5�      $
��Post��6&   $��8(�5�      6   �� 5�   
   $��1��6   $��2��6"   $��20��5�      $��10 -155 0 0q�6   ��5�      �� $ Post.MESSAGE��� 5�   
   -   5         ��Name$ 
LbPostList��5�      $��Stretch=�6'   $��1��6L   $��3��6\   $��	10 10 0 0q�5�      #��[ 6%   ��5�   2   �� $ Posts�$ TwoWay=� .  . $ PropertyChanged=� � ContextMenu 5�      �� 5�      -   5        $��cm��5�       �� 	StaysOpen . .@�5�      m� -   5        $��Delete��5�      6/   m� 5�      -	   5        $��Update��5�      6/   5�      5�      5�      5�      