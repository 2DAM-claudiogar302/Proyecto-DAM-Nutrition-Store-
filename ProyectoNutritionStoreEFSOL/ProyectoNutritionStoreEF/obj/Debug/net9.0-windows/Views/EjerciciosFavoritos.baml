   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   ]3clr-namespace:ProyectoNutritionStoreEF.UserControls%ProyectoNutritionStoreEF.UserControls  5   	   8    2ProyectoNutritionStoreEF.Views.EjerciciosFavoritos   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	   Gcontrol3clr-namespace:ProyectoNutritionStoreEF.UserControls     5   	     � Title$  EjerciciosFavoritos��5	   	   $	��600��6%   $	��458��62   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $	��10* �6   6+   �� 5      $��2* �6   6*   .+�5   
   � $��0��6   .+�5      2   ,ProyectoNutritionStoreEF.UserControls.Header  6   5      � 5   
   $��1��6   .+�5      �� $#��Bienvenido a Nutrition Store.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Bottom=�6O   .+�5      �� $��Inicio��6   
 � Tag$ Inicio��6*   $��10(�5      $
��20,0q�5         MenuButtonStyle#��[  66   ��6   �� *VistaEntrenamiento+66   �� 5      $��Espalda��6   $ Espalda��6+   $��10(�5      $
��20,0q�5      #��[  60   ��6   �� *VistaEspalda+60   �� 5!      $��Pecho��6   $ Pecho��6)   $��10(�5"      $
��20,0q�5#      #��[  6.   ��6   �� *
VistaPecho+6.   �� 5%      $��Brazo��6   $ Brazo��6)   $��10(�5&      $
��20,0q�5'      #��[  6.   ��6   �� *
VistaBrazo+6.   �� 5)      $��Pierna��6   $ Pierna��6*   $��10(�5*      $
��20,0q�5+      #��[  62   ��6   �� *VistaPierna+62   �� 5-      $��	Favoritos��6   $ 	Favoritos��6-   $��10(�5.      $
��20,0q�5/      #��[  62   ��6   �� *VistaFavoritos+62   50      51      � 52   
   $��2��6   .+�53      �� $
��Auto=�6   $��Disabled=�6@   .��54      �� ��6   �� *EjerciciosFavoritos+��55      �� 56      .R�57      �� $ 
Horizontal=�6)   58      ��5:      �� 5;      .R�5<      �� $	��200��6%   $	��300��61   $��10q�6>   
������� �� CornerRadius$ 10��6a   ._�5=   "   �� .+�5>   &   �� $	��150��6D   $	��150��6P   $��Center=�6]   ��6,   �� *Foto+6]   �� 5?   &   $
��Bold"�6H   $��16(�6Z    �� TextAlignment$ Center=�6h   $��0,10,0,0q�6   ��60   �� *Nombre+6   �� 5@   &   $
��Auto=�63   $��60��6V   $��5,0,5,5q�6b   .��5A   *   �� $
��Wrap=�6Q   $ Center=�6e   ��64   �� *Descripcion+6e   5B   '   �� 5C   &     bordesBoton#��[ 5F      ��5C   -   �� *!DataContext.RemoveEjercFavorito+ �� RelativeSource ��  �� AncestorType" ���5E      �� *ID+.��5G   *   �� $��/Resources/papelera.png��60   $��24��6Q   $��24��6\   5H   '   5J   #   5K      5L      5N      5P      5Q      � 5R   
   $��3��6   .+�5S      �� $#��Muchas gracias por su visita.��6   $��Center=�6=   $��0,15,0,0q�6Z   $
��Bold"�6l   6�   5T      5U      5V      