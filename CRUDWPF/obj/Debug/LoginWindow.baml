   M S B A M L   `   `   `  ����B  >CRUDWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CRUDWPFCRUDWPF  5   	       CRUDWPF.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CRUDWPF     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  LoginWindow��5	   	   $	��470��6   $	��300��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I    � 
ResizeMode$ NoResize=�6n   .��5
      � .+�5   
   �� $��1q�6   $
��Left=�6%   $	��225��6@   $
��-1,0q�6M   $	��Top=�6[   $	��302��6s    J� OpacityMask �	#FF130C0C��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFD11DD1��6#    � Offset$ 0Q�65   � 5      $ 	#FF122EE0��6#   $ 1Q�65   5      5      �� 5   
   $��1q�6   $
��Left=�6%   $	��228��6@   $��
56,104,0,0q�6M   $	��Top=�6a   $	��188��6y   
����������	#FFC9C4C4	 �� CornerRadius$	 10��6�   �� 5   
   -   5        
 ��Name$
 emailBox��5      $
��Left=�6$   $��29��6?   $��
76,191,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��150��6�    �� AcceptsReturn .   �� SelectionStart$ 1��6�   6�   �� 5   
   -   5         ��Name$ loginButton��5      $��Login��6&   $
��Left=�66   $��113,314,0,0q�6Q   $	��Top=�6f   $��75��6~   $��16(�6�   $��34��6�   6�   �� 5   
   -   5         ��Name$ label��5      $��Email��6   $
��Left=�6/   $��
76,165,0,0q�6J   $	��Top=�6^   $��16(�6v   �� 5   
   -   5        $ label1��5      $��Password��6    $
��Left=�63   $��
74,223,0,0q�6N   $	��Top=�6b   $��16(�6z    J� IsHitTestVisible .  6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��
74,241,0,0q�6F   $	��Top=�6Z   $	��153��6r   $��30��6~   6�   �� 5   
   -   5        $ label2��5      $��LOGIN��6    $
��Left=�60   $��117,114,0,0q�6K   $	��Top=�6`   $��75��6x   $��22(�6�    J� RenderTransformOrigin$ 
0.576,0.69&�6�   $��Roboto Light)�6�   �� 5   
   -   5        $ 
emailValid��5      $��Invalid Email Format��6$   $
��Left=�6C   $��
92,268,0,0q�6^   $	��Top=�6r   $	��124��6�   $��28��6�   ���	#DDFF02026�   �� 5   
   -   5         ��Name$ emailInsert��5      $
��Left=�6)   $��
78,199,0,0q�6D   $
��Wrap=�6X   $��Insert Email��6l   $	��Top=�6�   $��70��6�    .  
����İ�6�   �� 5   
   -	   5        $ 
passInsert��5      $
��Left=�6(   $��
80,251,0,0q�6C   $
��Wrap=�6W   $��Password��6k   $	��Top=�6{   $��69��6�    .  
����İ�6�   �� 5   
   -
   5        $ button��5      $
��Left=�6!   $��	251,4,0,0q�6<   $	��Top=�6O   $��48��6g   
���������6�   Z� ��6�   Z� .��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   $��23��63   $��19��6?   5!      �� 5"   
   -   5         ��Name$ checkBox��5"      $��Remember Me��6%   $
��Left=�6;   $��
98,360,0,0q�6V   $	��Top=�6j   $ 0.658,0.611&�6�   �� 5#   
   -   5        $ label3��5#      $
��Left=�6    $��
120,30,0,0q�6;   $	��Top=�6O   $��59��6g   
�������$��57��6�   .��5$        $ House=�6&   $��59��63   $��59��6?   $ 1.037,1.138&�6J   5%      �� 5&   
   -   5        $ label4��5&      $��Dont have an Account? ��6    $
��Left=�6A   $��23��6\   $��
87,416,0,0q�6h   $	��Top=�6|   $	��136��6�   �� 5'   
   -   5        $ 	textBlock��5'      $
��Left=�6'   $��121,439,0,0q�6B   $
��Wrap=�6W   $	��Top=�6k   $ -3.381,1.625&�6�   $��56��6�   �� 5(      -   5        $��Register.xaml?�5(      .�6`   
Click Here6l   5)      �� 5*   
   -   5        $ 
textBlock1��5*      $
��Left=�6(   $��103,387,0,0q�6C   $
��Wrap=�6X   $	��Top=�6l   �� 5+      -   5        $��ForgotPassword.xaml?�5+      .�6g   Forgot Password?6y   5,      5.      5/      