   M S B A M L   `   `   `  ����G  CImageGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ImageGalleryImageGallery  5   	       ImageGallery.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ImageGallery     5   	     � Title$  
MainWindow��5   	   $	��900��6   $
��1440��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��220 �6   �� 5      $��* �6   �� 5      $	��220 �6   .+�5   
   �� -   5           Left#��[  5      .��5      �� $��Images/left.png��6   $
��Fill=�6-   6?   5      �� 5   
   -   5         ��Name$ 	imgLoaded��5      $��1��6=   ��6#   �� *ImgStr+6O   �� 5   
   -   5         ��Name$ btnRight��5       	 Right#��[ 6#   .��5      �� $��Images/right.png��6   $
��Fill=�6.   6?   5      �� 5   
   -   5        $ btnLeft��5        CircleButton#��[ 6"   .��5      �� $��Images/add.png��6   6.   5      5      5      