   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5   	   Y1clr-namespace:ProyectoNutritionStoreEF.ViewModels#ProyectoNutritionStoreEF.ViewModels  6M   *    $ProyectoNutritionStoreEF.Views.Index   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5   	   H
viewmodels1clr-namespace:ProyectoNutritionStoreEF.ViewModels     6M     � Icon$(  "/Resources/Logo_NutritionStore.png��5	   	    � Title$ Index��5
   	   $	��600��6   $	��458��6$   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      �� $;��5Bienvenido a la página principal de Nutrition Store.��6   $��Center=�6T   $��0,15,0,0q�6q   $
��Bold"�6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5      $
��20,0q�5         MenuButtonStyle2#��[  5      ��5      �� *
VistaIndex+�� 5       $��
Proteínas��6   $ 
Proteínas��6-   $��10(�5!      $
��20,0q�5"      #��[  5#      ��5$      �� *VistaProteinas+�� 5&      $��	Vitaminas��6   $ 	Vitaminas��6-   $��10(�5'      $
��20,0q�5(      #��[  5)      ��5*      �� *VistaVitaminas+�� 5,      $��Aminoácidos��6   $ Aminoácidos��6/   $��10(�5-      $
��20,0q�5.      #��[  5/      ��50      �� *VistaAminoacidos+�� 52      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�53      $
��20,0q�54      #��[  55   $   ��6   �� *VistaFavoritos+6$   56      57      � 58   
   $��2��6   .+�59      �� $
��Auto=�6   $��Disabled=�6@   .��5:      �� ��6   �� *SuplementosTendencia+��5;      �� 5<      .R�5=      �� $ 
Horizontal=�6)   5>      ��5@      �� 5A      .R�5B      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5C   "   �� .+�5D   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5E   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5F   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5G   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5H   '   �� 5I   &     bordesBoton#��[ 5L      ��5I   -   �� *DataContext.AddSuplemFavorito+ �� RelativeSource ��  �� AncestorType" ���5K      �� *ID+.��5M   *   �� $��/Resources/favorito.png��60   $��24��6Q   $��24��6\   5N   '   5O   #   5P      5Q      5S      5U      5V      � 5W   
   $��3��6   .+�5X      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5Y      5\      5]      