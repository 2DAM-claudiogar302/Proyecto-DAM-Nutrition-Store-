   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5      *    $ProyectoNutritionStoreEF.Views.Brazo   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5        � Icon$(  "/Resources/Logo_NutritionStore.png��5	   	    � Title$ Brazo��5
      $	��600��6   $	��458��6   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�5      $��Center=�6   $��20q�5      
����� �.+�5      �� -   5        $��buscador��5      $��15(�5      $	��224��5      
���   ���5      �� *Value+.��6&   5      �� 5       $��1,0,0,0q�6   ���	#FFFFFCFC$��30��6B   ��6M   �� *SearchCommandGrupo+��5!      �� 5"       �� ImageSource$ /Resources/lupa.png��6%   5%      5'      �� 5(      $ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5)      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5*      $
��20,0q�5+         MenuButtonStyle#��[  66   ��6   �� *VistaEntrenamiento+66   �� 5-      $��Espalda��6   $ Espalda��6+   $��10(�5.      $
��20,0q�5/      #��[  60   ��6   �� *VistaEspalda+60   �� 51      $��Pecho��6   $ Pecho��6)   $��10(�52      $
��20,0q�53      #��[  6.   ��6   �� *
VistaPecho+6.   �� 55      $��Brazo��6   $ Brazo��6)   $��10(�56      $
��20,0q�57      #��[  6.   ��6   �� *
VistaBrazo+6.   �� 59      $��Pierna��6   $ Pierna��6*   $��10(�5:      $
��20,0q�5;      #��[  62   ��6   �� *VistaPierna+62   �� 5=      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�5>      $
��20,0q�5?      #��[  62   ��6   �� *VistaFavoritos+62   5@      5A      � 5B   
   $��2��6   .+�5C      �� $
��Auto=�6   $��Disabled=�6@   .��5D      �� ��6   �� *Brazo+��5E      �� 5F      .R�5G      �� $ 
Horizontal=�6)   5H      ��5J      �� 5K      .R�5L      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5M   "   �� .+�5N   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5O   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5P   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5Q   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5R   '   �� 5S   &     bordesBoton#��[ 5V   	   ��5S   -   �� *" DataContext.AddEjercicioFavorito+ �� RelativeSource �� 	 �� AncestorType"	 ���5U   	   �� *ID+.��5W   *   �� $��/Resources/favorito.png��60   $��24��6Q   $��24��6\   5X   '   5[   #   5\      5]      5_      5a      5b      � 5c   
   $��3��6   .+�5d      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5e      5h      5i      