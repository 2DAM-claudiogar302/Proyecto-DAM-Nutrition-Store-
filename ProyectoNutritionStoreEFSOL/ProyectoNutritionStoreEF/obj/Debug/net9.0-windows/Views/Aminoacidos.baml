   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5   	   Y1clr-namespace:ProyectoNutritionStoreEF.ViewModels#ProyectoNutritionStoreEF.ViewModels  5   	   0    *ProyectoNutritionStoreEF.Views.Aminoacidos   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5   	   H
viewmodels1clr-namespace:ProyectoNutritionStoreEF.ViewModels     5   	     � Icon$(  "/Resources/Logo_NutritionStore.png��5
   	    � Title$ Aminoacidos��5   	   $	��600��6   $	��458��6*   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�5      $��Center=�6   $��20q�5      
����� �.+�5      �� -   5        $��buscador��5      $��15(�5      $	��224��5      
���   ���5      �� *Value+.��6&   5       �� 5!      $��1,0,0,0q�6   ���	#FFFFFCFC$��30��6B   ��6M   �� *SearchCommandCategoria+��5"      �� 5#       �� ImageSource$ /Resources/lupa.png��6%   5&      5(      �� 5*      $ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5+      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5,      $
��20,0q�5-         MenuButtonStyle2#��[  5.      ��5/      �� *
VistaIndex+�� 51      $��
Proteínas��6   $ 
Proteínas��6-   $��10(�52      $
��20,0q�53      #��[  54      ��55      �� *VistaProteinas+�� 57      $��	Vitaminas��6   $ 	Vitaminas��6-   $��10(�58      $
��20,0q�59      #��[  5:      ��5;      �� *VistaVitaminas+�� 5=      $��Aminoácidos��6   $ Aminoácidos��6/   $��10(�5>      $
��20,0q�5?      #��[  5@      ��5A      �� *VistaAminoacidos+�� 5C      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�5D      $
��20,0q�5E      #��[  5F   1   ��6   �� *VistaFavoritos+61   5G      5H      � 5I   
   $��2��6   .+�5J      �� $
��Auto=�6   $��Disabled=�6@   .��5K      �� ��6   �� *Aminoacidos+��5L      �� 5M      .R�5N      �� $ 
Horizontal=�6)   5O      ��5Q      �� 5R      .R�5S      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5T   "   �� .+�5U   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5V   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5W   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5X   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5Y   '   �� 5Z   &     bordesBoton#��[ 5]   	   ��5Z   -   �� *DataContext.AddSuplemFavorito+ �� RelativeSource �� 	 �� AncestorType"	 ���5\   	   �� *ID+.��5^   *   �� $��/Resources/favorito.png��60   $��24��6Q   $��24��6\   5_   '   5a   #   5b      5c      5e      5g      5h      � 5i   
   $��3��6   .+�5j      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5k      5l      5m      