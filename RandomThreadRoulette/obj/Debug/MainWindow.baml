   M S B A M L   `   `   `  ����O  KRandomThreadRoulette, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RandomThreadRoulette.ControlsRandomThreadRoulette.Controls  5   	   d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes 5   	   %    RandomThreadRoulette.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @Controls+clr-namespace:RandomThreadRoulette.Controls     5   	   fclassicThemeMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     5   	   -   5          �Name$  MainWindowRoulette��5   	    � Title$ 
MainWindow��5   	   $��399.25��6   $��742.402��6,    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$
 None=�6D    � AllowsTransparency . 
������� � 	Resources 5         basicButton �� 
TargetType �� Property	 �� Value5  /Microsoft.Windows.Themes.ClassicBorderDecorator
   ClassicBorderBrush �� 
TargetType  Name   BorderBrush   BorderThickness   BorderStyle   
Background J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%$  &	        �� 5   
   " ��6$   .�5      ��  � ��#	 � ��6+   �� 5       � ��#	 � ��6+   �� 5       � ��#	 Z
 6,   �� 5       � ��	 5      �� 5      " ��6&   .R�5        $ ContentContainer��6>   # z��6X   $ 0q�6�   $
 None=�6�   # z��6�    . ._�5      �� #��z��6/   #��z��6r   ��. # z 6�   #��z��6�   5       5      P� 5       �@J�IsKeyboardFocused . . �5   "   �� $ ContentContainer��6@    �@ BorderStyle$	 RaisedFocused=�6^   5      P� 5       �@��IsDefaulted . . �5   "   �� $ ContentContainer��6@    �@ BorderStyle$	 RaisedFocused=�6^   5      P� 5       � �� . . �5   "   �� $ ContentContainer��6@    �@ BorderStyle$	 RaisedPressed=�6^   5       P� 5!       �@d�	IsChecked$
 TrueY�6H   . �5"   "   �� $ ContentContainer��6@    �@ BorderStyle$	 RaisedPressed=�6^   5#      P� 5$       � {� .  . �5%   "   �� #	 � ��6?    � ��5&      5(      5*      5+      5-      .��5/      � .+�51   
   �� -   5         ��Name$ TopPanel��51      $��	0,0,0.4,0q�6'   
����� � �� Orientation$ 
Horizontal=�52      $��40��6.   $	��Top=�6:   .+�54      �� $��Simple fruit machine��6   $��	200,0,0,0q�64    �� TextAlignment$ Center=�6G    �� Padding$ 2q�55      ���	#FFFFCA8A$��Segoe Print)�6.   $��20(�6G   $��Medium"�6U   $	��263��6i   �� 57      -   5         ��Name$ btnBackToMenu��57      $��	225,0,0,0q�6,   #���   6?   
������ 
������ 
������ $��47��58   H   .��59      �� $��Media/close.png��6   5:      5;      �� 5>   
   -   5         ��Name$ 	seperator��5>      $��10,306,10.4,0q�6#   $	��Top=�6:   ���	#FF6D65C0$��2��6i   �� 5A   
   -   5        $ FirstResultPanel��5A      $
��Left=�6/   $��500,207,0,0q�6J   $	��Top=�6_   $	��232��6w   .+�5B      �� -   5         ��Name$ txtTimer��5B      $��16(�6*   $��Medium"�68   ���#E79344$
��Left=�5C      $
��Wrap=�63   $��Timer��6G   $	��Top=�6T   �� 5E      $
��Left=�6   $��16(�63   $��Medium"�6A   ���#E79344$
��Wrap=�5F      $��Result image��6,   $	��Top=�6@   �� 5H      -   5        $ txtNumb��5H      $
��Left=�6)   $��16(�6D   $��Medium"�6R   ���#E79344$
��Wrap=�5I   -   $��Result number��6A   $	��Top=�6V   �� 5J      -   5         ��Name$ firstResImage��5J      5K      �� 5O   
   -	   5        $ MainResultPanel��5O      ���	#FFB0E6AD$
��Left=�6E   $��	10,0,0,10q�5P      $	��722��6(   $��67��64   $��Bottom=�6@   .+�5R      �� -
   5        $ txtResImages��5R      $
��Left=�6.   $��10,2,0,0q�6I   $
��Wrap=�6[   $��14(�6o   $��Medium"�5S      ���	#FF014040$	��Top=�6C   �� 5T      -   5        $ txtResNumbers��5T      $
��Left=�6/   $��10,2,0,0q�6J   $
��Wrap=�6\   $��14(�6p   $��Medium"�5U      ���	#FF014040$	��Top=�6C   �� 5V      -   5        $ txtRes��5V      $
��Left=�6(   $��10,3,0,0q�6C   $
��Wrap=�6U   $��14(�6i   $��Medium"�5W      ���	#FF014040$	��Top=�6C   5X      �� 5\   
   -   5        $ btnStart��5\      
����� �
�������$��14(�6L   $��Start��6Z   #��[  5]      $
��Left=�66   $��657,277,0,0q�5^      $	��Top=�6&   $��75��6>   6I   �� 5b   
   $��23,0,259.4,107.2q�6    �� CornerRadius$ 10��6+   
����� �$��2q�6T   $	��186��6h   $��Bottom=�6u   ._�5c      � .+�5d      3   -RandomThreadRoulette.Controls.RouletteControl  -   5          Name$ control1��5d   +   $
��Left=�6=   $	��Top=�6X     5e      -   5        $ control2��5e   +   $
��Left=�6=   $��	155,0,0,0q�6X   $	��Top=�6k     5f      -   5        $ control3��5f   +   $
��Left=�6=   $��	310,0,0,0q�6X   $	��Top=�6k   5g      5h      �� 5k   
   -   5        $ seperator_Copy��5k      $��10,88,10.4,0q�6(   $	��Top=�6>   ���	#FF6D65C0$��2��6m   �� 5n   
   -   5        $ txtUser��5n      
��� d �$��16(�6<   $��Medium"�6J   $
��Left=�5o      $��	23,45,0,0q�6/   $
��Wrap=�6B   $��	TextBlock��6V   $	��Top=�6g   �� 5p   
   -   5        $ 	txtPoints��5p      $
��Left=�6'   $��14(�6B   
�������$��Medium"�6b   $��	23,66,0,0q�5q      $
��Wrap=�6'   $��	TextBlock��6;   $	��Top=�6L   �� 5t   
   -   5        $ imageWin��5t      $y�	Collapsed=�6"   $
��Left=�69   $	��122��6T   $��575,111,0,0q�5u      $	��Top=�6%   $	��149��6=   $��Media/win.png��6I   5w      5x      