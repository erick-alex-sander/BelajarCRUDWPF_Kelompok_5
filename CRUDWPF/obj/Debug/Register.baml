   M S B A M L   `   `   `  ����B  >CRUDWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRUDWPFCRUDWPF  5          CRUDWPF.Register   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:CRUDWPF     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � WindowStyle$
  None=�5	   #    � 
ResizeMode$ NoResize=�66   $	��797��6L    � WindowStartupLocation$ CenterScreen=�6X   .��5
      � 
�������$��0,0,-4,0q�6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��	48,27,0,0q�6B   $
��Wrap=�6U   $��Registration Form��6i   $	��Top=�6�   $��48(�6�   $��Segoe UI Light)�6�   �� 5   
   -   5         ��Name$ obaom54f_bmp��5      $��34,153,391,30q�6&   $��obaom54f.bmp��6=   $
��Fill=�6S   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��470,110,0,0q�6C   $
��Wrap=�6X   $&�� Please Fill in Registration form��6l   $	��Top=�6�   $��22(�6�   $	��304��6�   $��Roboto Light)�6�   �� 5   
   -   5        $ 
textBlock2��5      $
��Left=�6(   $��472,140,0,0q�6C   $
��Wrap=�6X   $��All fields are required��6l   $	��Top=�6�   $��16(�6�   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��457,208,0,0q�6C   $
��Wrap=�6X   $��UserName��6l   $	��Top=�6|   $��16(�6�   �� 5   
   -   5        $ 
textBlock4��5      $
��Left=�6(   $��456,271,0,0q�6C   $
��Wrap=�6X   $��Password��6l   $	��Top=�6|   $��16(�6�   �� 5   
   -   5        $ 
textBlock5��5      $
��Left=�6(   $��457,341,0,0q�6C   $
��Wrap=�6X   $��Re-Type Password��6l   $	��Top=�6�   $��16(�6�   �� 5   
   -   5         ��Name$ userBox��5      $��35��6#   $��607,201,32,0q�6/    �� TextWrapping$
 Wrap=�6E   $	��Top=�6Y   $��16(�6q   6�   G� 5   
   -	   5         G�Name$ passBox��5      $
��Left=�6'   $��35��6B   $��607,261,0,0q�6N   $	��Top=�6c   $	��165��6{    J� RenderTransformOrigin$ 0.717,2.172&�6�   $��16(�6�   6�   G� 5   
   -
   5        $ 	repassBox��5      $
��Left=�6)   $��33��6D   $��606,334,0,0q�6P   $	��Top=�6e   $	��169��6}   $��16(�6�   6�   �� 5   
   -   5        	 ��Name$	 submitButton��5      $��Submit��6'   $
��Left=�68   $��657,408,0,0q�6S   $	��Top=�6h   $��84��6�   $ 1.813,0.375&�6�   ���	#FF21F321$��16(�6�   ��6�   Z� 6�   �� 5   
   -   5        $	 refresh��5      $
��Left=�6"   $��580,410,0,0q�6=   $	��Top=�6R   $��53��6j   $ 
0.587,0.75&�6u   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Refresh=�6&   $ -0.25,0.562&�65   $��-1,-1q�6Y   5      �� 5   
   -   5         ��Name$ 
emailLabel��5      $��Insert Email��6$   $
��Left=�6;   $��608,205,0,0q�6V   $	��Top=�6k   $ 	0.362,0.5&�6�   $��16(�6�   
����İ� J� IsHitTestVisible .  6�   �� 5   
   -   5        $ 	passLabel��5      $��Insert Password��6#   $
��Left=�6=   $��606,266,0,0q�6X   $	��Top=�6m   $ 	0.362,0.5&�6�   $��16(�6�   
����İ� .  6�   �� 5   
   -   5        $ passreLabel��5      $��Insert Password��6%   $
��Left=�6?   $��610,337,0,0q�6Z   $	��Top=�6o   $ 	0.362,0.5&�6�   $��16(�6�   
����İ� .  6�   �� 5!   
   -   5        $ warningEmail��5!      $
��Left=�6*   $��612,238,0,0q�6E   $
��Wrap=�6Z   $��Wrong Email Format��6n   $	��Top=�6�   
���  ��6�   �� 5"   
   -   5        $ warningPass��5"      $
��Left=�6)   $��612,294,0,0q�6D   $
��Wrap=�6Y   $6��0Password must contain >=8 Alphanumeric and Cases��6m   $	��Top=�6�   
���  ��6�   �� 5#   
   -   5        $ warningPassre��5#      $
��Left=�6+   $��613,366,0,0q�6F   $
��Wrap=�6[   $!��Password must same as above��6o   $	��Top=�6�   
���  ��6�   �� 5%   
   -   5        $��741,-32,11,441q�5%      $
��Auto��6)   ���	#FF080808$ 0.5,0.5&�6{   ��6N   Z� ��6e   Z� z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*       �� Angle$ 2.055Q�6&   T� 5+      5,      .��5.        $
 Close=�6&   5/      50      51      