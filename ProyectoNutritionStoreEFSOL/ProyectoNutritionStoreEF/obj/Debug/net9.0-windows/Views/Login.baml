   M S B A M L   `   `   `  ����S  OProyectoNutritionStoreEF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ProyectoNutritionStoreEF.ViewsProyectoNutritionStoreEF.Views  5   	   *    $ProyectoNutritionStoreEF.Views.Login   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ProyectoNutritionStoreEF.Views     5   	     � Icon$(  "/Resources/Logo_NutritionStore.png��5   	    � Title$ Login��5	   	   $	��550��6   $	��400��6$   .��5
      �  � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      $��5* �6   6*   �� 5      $��* �6   6)   ��5   
   �� 5       �� ImageSource$ /Resources/login.png��6   .+�5   
   � $��0��6   .+�5      �� $(��"/Resources/Logo_NutritionStore.png��6   $��Center=�5      $��Center=�5      $	��170��5      $	��200��6   $��	0,-11,0,0q�6!   5      � 5   
   $��1��6   .+�5      ��  �� CornerRadius$ 15��6   $��2q�6'   ���#B58E8E   colorPrimario1#��[  6Q   $��Center=�6~   $��	0,10,0,10q�6�   ._�5       �� #��[  6   $	��211��6J   $��0,8,0,19q�6V   .+�5!      �� $��10q�6!   $	��292��6-   .+�5"      �� $��/Resources/userLogin.png��6    $��10q�6B   $��20��6N   $��Center=�6Y   $��19��6v   �� 5#      $��Center=�6$   $
��Bold"�6A   $��0,10,0,0q�6S   $��28��6e   �� 5$      $�Bienvenido a ��6
   
���   �6    �� 5%      $�Nutrition Store��6
     colorSecundario4#��[ 6!   5&      �� 5'      $
��Bold"�6    $
��Left=�62   $��15(�6M   $��Noto Sans Thin Condensed)�6[   ���#B58E8E$��10,0,0,0q�6�   $��35��6�   .��6�   	Usuario5)      �� 5*      -   5         ��Name$
 user��5*   "   $��
10,0,10,10q�60   $��15(�6D   ��6R   �� *
Username+�� 5+      $
��Bold"�6    $
��Left=�62   $��15(�6M   $��Noto Sans Thin Condensed)�6[   ���#B58E8E$��10,0,0,0q�6�   $��33��6�   .��6�   Contraseña5-      G� 5.      -   5         G�Name$ password��5.   &   $��
10,0,10,10q�68   $��15(�6L   $��24��6Z   6f   �� 5/      $��0,12,0,0q�6!   $��34��50      $��15(�6   $��Iniciar sesión��51      $	��140��52        BotonConIconoLogin#��[ 53      
���   �$
��Bold"�56   	   $��Noto Sans Thin Condensed)�57      ��54      �� *LoginCommand+57      58      59      5:      5;      � 5=   
   $��2��6   .+�5>      �� -   5          TransparentButtonStyle#��[ 5>      .��5?      �� $��Center=�6   $	��Top=�69   $
��Bold"�6Q   $��0,10,0,0q�6c   $��Forgot your password? ��5@        colorSecundario1#��[ 6*   5A      5B      5C      5D      5E      