   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5   
   .    (ProyectoNutritionStoreEF.Views.Proteinas   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5   
     � Icon$(  "/Resources/Logo_NutritionStore.png��5   	    � Title$ 	Proteinas��5
      $	��600��6   $	��458��6!   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�5      $��Center=�6   $��20q�5      
����� �.+�5      �� -   5        $��buscador��5      $��15(�5      $	��224��5      
���   ���5      �� *Value+.��6&   5      �� 5       $��1,0,0,0q�6   ���	#FFFFFCFC$��30��6B   ��6M   �� *SearchCommandCategoria+��5!      �� 5"       �� ImageSource$ /Resources/lupa.png��6%   5%      5'      �� 5)      $ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5*      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5+      $
��20,0q�5,         MenuButtonStyle2#��[  5-      ��5.      �� *
VistaIndex+�� 50      $��
Proteínas��6   $ 
Proteínas��6-   $��10(�51      $
��20,0q�52      #��[  53      ��54      �� *VistaProteinas+�� 56      $��	Vitaminas��6   $ 	Vitaminas��6-   $��10(�57      $
��20,0q�58      #��[  59      ��5:      �� *VistaVitaminas+�� 5<      $��Aminoácidos��6   $ Aminoácidos��6/   $��10(�5=      $
��20,0q�5>      #��[  5?      ��5@      �� *VistaAminoacidos+�� 5B      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�5C      $
��20,0q�5D      #��[  5E   %   ��6   �� *VistaFavoritos+6%   5F      5G      � 5H   
   $��2��6   .+�5I      �� $
��Auto=�6   $��Disabled=�6@   .��5J      �� ��6   �� *	Proteinas+��5K      �� 5L      .R�5M      �� $ 
Horizontal=�6)   5N      ��5P      �� 5Q      .R�5R      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5S   "   �� .+�5T   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5U   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5V   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5W   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5X   '   �� 5Y   &     bordesBoton#��[ 5\      ��5Y   -   �� *DataContext.AddSuplemFavorito+ �� RelativeSource �� 	 �� AncestorType"	 ���5[      �� *ID+.��5]   *   �� $��/Resources/favorito.png��60   $��24��6Q   $��24��6\   5^   '   5_   #   5`      5a      5c      5e      5f      � 5g   
   $��3��6   .+�5h      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5i      5j      5k      