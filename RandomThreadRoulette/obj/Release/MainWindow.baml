   M S B A M L   `   `   `  ���� O  KRandomThreadRoulette, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RandomThreadRoulette.ControlsRandomThreadRoulette.Controls  d `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes %    RandomThreadRoulette.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @Controls+clr-namespace:RandomThreadRoulette.Controls     fclassicThemeMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     -     �Name$  MainWindowRoulette�� � Title$ 
MainWindow��$��399.25��$��742.402�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������� � 	Resources    basicButton �� 
TargetType �� Property	 �� Value5  /Microsoft.Windows.Themes.ClassicBorderDecorator
   ClassicBorderBrush �� 
TargetType  Name   BorderBrush   BorderThickness   BorderStyle   
Background J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� " ��.���  � ��#	 � ����  � ��#	 � ����  � ��#	 Z
 ��  � ��	 �� " ��.R�  $ ContentContainer��# z��$ 0q�$
 None=�# z�� . ._��� #��z��#��z����. # z #��z�� P�  �@J�IsKeyboardFocused . . ��� $ ContentContainer�� �@ BorderStyle$	 RaisedFocused=�P�  �@��IsDefaulted . . ��� $ ContentContainer�� �@ BorderStyle$	 RaisedFocused=�P�  � �� . . ��� $ ContentContainer�� �@ BorderStyle$	 RaisedPressed=�P�  �@d�	IsChecked$
 TrueY�. ��� $ ContentContainer�� �@ BorderStyle$	 RaisedPressed=�P�  � {� .  . ��� #	 � �� � ��.��� .+��� -    ��Name$ TopPanel��$��	0,0,0.4,0q�
����� � �� Orientation$ 
Horizontal=�$��40��$	��Top=�.+��� $��Simple fruit machine��$��	200,0,0,0q� �� TextAlignment$ Center=� �� Padding$ 2q����	#FFFFCA8A$��Segoe Print)�$��20(�$��Medium"�$	��263���� -    ��Name$ btnBackToMenu��$��	225,0,0,0q�#���   
������ 
������ 
������ $��47��.���� $��Media/close.png���� -    ��Name$ 	seperator��$��10,306,10.4,0q�$	��Top=����	#FF6D65C0$��2���� -   $ FirstResultPanel��$
��Left=�$��500,207,0,0q�$	��Top=�$	��232��.+��� -    ��Name$ txtTimer��$��16(�$��Medium"����#E79344$
��Left=�$
��Wrap=�$��Timer��$	��Top=��� $
��Left=�$��16(�$��Medium"����#E79344$
��Wrap=�$��Result image��$	��Top=��� -   $ txtNumb��$
��Left=�$��16(�$��Medium"����#E79344$
��Wrap=�$��Result number��$	��Top=��� -    ��Name$ firstResImage���� -	   $ MainResultPanel�����	#FFB0E6AD$
��Left=�$��	10,0,0,10q�$	��722��$��67��$��Bottom=�.+��� -
   $ txtResImages��$
��Left=�$��10,2,0,0q�$
��Wrap=�$��14(�$��Medium"����	#FF014040$	��Top=��� -   $ txtResNumbers��$
��Left=�$��10,2,0,0q�$
��Wrap=�$��14(�$��Medium"����	#FF014040$	��Top=��� -   $ txtRes��$
��Left=�$��10,3,0,0q�$
��Wrap=�$��14(�$��Medium"����	#FF014040$	��Top=��� -   $ btnStart��
����� �
�������$��14(�$��Start��#��[  $
��Left=�$��657,277,0,0q�$	��Top=�$��75���� $��23,0,259.4,107.2q� �� CornerRadius$ 10��
����� �$��2q�$	��186��$��Bottom=�._�� .+�3   -RandomThreadRoulette.Controls.RouletteControl  -     Name$ control1��$
��Left=�$	��Top=�  -   $ control2��$
��Left=�$��	155,0,0,0q�$	��Top=�  -   $ control3��$
��Left=�$��	310,0,0,0q�$	��Top=��� -   $ seperator_Copy��$��10,88,10.4,0q�$	��Top=����	#FF6D65C0$��2���� -   $ txtUser��
��� d �$��16(�$��Medium"�$
��Left=�$��	23,45,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=��� -   $ 	txtPoints��$
��Left=�$��14(�
�������$��Medium"�$��	23,66,0,0q�$
��Wrap=�$��	TextBlock��$	��Top=��� -   $ imageWin��$y�	Collapsed=�$
��Left=�$	��122��$��575,111,0,0q�$	��Top=�$	��149��$��Media/win.png��