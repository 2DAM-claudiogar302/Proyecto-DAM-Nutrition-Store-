   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5   	   2    ,ProyectoNutritionStoreEF.Views.Entrenamiento   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5   	     � Icon$(  "/Resources/Logo_NutritionStore.png��5	   	    � Title$ Entrenamiento��5
   	   $	��570��6   $	��458��6,   .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      �� $;��5Bienvenido a la página principal de Nutrition Store.��6   $��Center=�6T   $��0,15,0,0q�6q   $
��Bold"�6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5      $
��20,0q�5         MenuButtonStyle#��[  66   ��6   �� *VistaEntrenamiento+66   �� 5      $��Espalda��6   $ Espalda��6+   $��10(�5      $
��20,0q�5       #��[  60   ��6   �� *VistaEspalda+60   �� 5"      $��Pecho��6   $ Pecho��6)   $��10(�5#      $
��20,0q�5$      #��[  6.   ��6   �� *
VistaPecho+6.   �� 5&      $��Brazo��6   $ Brazo��6)   $��10(�5'      $
��20,0q�5(      #��[  6.   ��6   �� *
VistaBrazo+6.   �� 5*      $��Pierna��6   $ Pierna��6*   $��10(�5+      $
��20,0q�5,      #��[  62   ��6   �� *VistaPierna+62   �� 5.      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�5/      $
��20,0q�50      #��[  62   ��6   �� *VistaFavoritos+62   51      52      � 53   
   $��2��6   .+�54      �� $
��Auto=�6   $��Disabled=�6@   .��55      �� ��6   �� *EjerciciosTendencia+��56      �� 57      .R�58      �� $ 
Horizontal=�6)   59      ��5;      �� 5<      .R�5=      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5>   "   �� .+�5?   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5@   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5A   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5B   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5C   '   �� 5D   &     bordesBoton#��[ 5G   	   ��5D   -   �� *" DataContext.AddEjercicioFavorito+ �� RelativeSource ��  �� AncestorType" ���5F   	   �� *ID+.��5H   *   �� $��/Resources/favorito.png��60   $��24��6Q   $��24��6\   5I   '   5K   #   5L      5M      5O      5Q      5R      � 5S   
   $��3��6   .+�5T      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5U      5V      5W      