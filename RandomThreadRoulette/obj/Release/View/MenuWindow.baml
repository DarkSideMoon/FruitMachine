   M S B A M L   `   `   `  ���� d  `PresentationFramework.Classic, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35jMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.ClassicMicrosoft.Windows.Themes  O KRandomThreadRoulette, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RandomThreadRoulette.ControlsRandomThreadRoulette.Controls *   $RandomThreadRoulette.View.MenuWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     fclassicThemeMclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic     @Controls+clr-namespace:RandomThreadRoulette.Controls       � Title$  
MenuWindow��$��498.6��$��762.2�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � 	Resources  �� 
TargetType �� Property �� Value6  0RandomThreadRoulette.Controls.AchievementControl 
  FadeIn	 g� Duration
 �� TargetProperty W� From	 W� To  FadeOut  btnGlass �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin � RowDefinitions ��Name �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY  basicButton5   /Microsoft.Windows.Themes.ClassicBorderDecorator   ClassicBorderBrush  Name   BorderBrush   BorderThickness   BorderStyle   
Background J� SnapsToDevicePixels��%"  '��       &	  c     &	 �     &	 �     &	 S    �� " ��.���  � �� �� .R�� ��  � �� �� .R�  ��  � ��$ Hidden=��� .��W� $	 0:0:1.35D�$
 Opacity�$ 0X�$ 1X��� .��W� $	 0:0:.55D�$
 Opacity�$ 0X��� " ��.���  � ��$ 14(���  � ��
 �������  � �� �� " ��.R��� $ ButtonBorder��$ 50��$��4q�
���  ��
�������$ 0.5,0.5&�$��0,0,21,0q�._��  �� $��* ��� $
��1.7* �.+��� $ ButtonContentPresenter��$��Center=�$��Center=�$��2�� P�  � �� . . ��� $ ButtonBorder�� � z� V� .~��� $	 0.9Q�$	 0.9Q��� " ��.���  � ��# � ����  � ��# � ����  � ��# Z ��  � �� �� " ��.R�  $ ContentContainer��# z��$ 0q�$
 None=�# z�� . ._��� #��z��#��z����. # z #��z�� P�  �@J�IsKeyboardFocused . . ��� $ ContentContainer�� �@ BorderStyle$ RaisedFocused=�P�  �@��IsDefaulted . . ��� $ ContentContainer�� �@ BorderStyle$ RaisedFocused=�P�  � �� . . ��� $ ContentContainer�� �@ BorderStyle$ RaisedPressed=�P�  �@d�	IsChecked$
 TrueY�. ��� $ ContentContainer�� �@ BorderStyle$ RaisedPressed=�P�  � {� .  . ��� # � �� � ��.��� $��81,45,90.6,55.2q�
������ .+��� -   $ 
blueBorder�����	#FFDDE9FF$
��Left=�$	��398��$��
2,0,-0.2,0q�$	��Top=�$	��589��$ 0.5,0.5&�z�V� .~��� �� ��   �� Angle$  -6.291Q�T� �� -   $ greenBorder�����	#FFB2FF95$
��Left=�$	��398��$��
2,0,-0.2,0q�$	��Top=�$	��589��$ 0.5,0.5&�z�V� .~��� �� �� $  -3.474Q�T� �� -   $ 	redBorder�����	#FFFF9595$
��Left=�$	��398��$��
2,0,-0.2,0q�$	��Top=�$	��589��$ 0.5,0.5&�z�V� .~��� �� �� $  7.466Q�T� �� -   $ yellowBorder�����	#FFFFF19A$
��Left=�$	��398��$��
2,0,-0.2,0q�$	��Top=�$	��589��$ 0.5,0.5&�z�V� .~��� �� �� $  4.526Q�T� �� -   $ 
mainBorder�����	#CCFFFFFF$
��Left=�$	��398��$	��Top=�$	��591��$ 0.5,0.5&�$��
0,0,-0.2,0q��� -   ! ��Name$! 	seperator�����	#FF3D7ED1$	��Top=�$��2��$��29,262,9.8,0q��� -   " ��Name$" mainMenu��$��29,24,327.6,186.2q�.+��� -   $ borderSingle�����	#00000000$��1q�$
��Left=�$��42��$��Bottom=�$	��156��$ 0.5,0.5&����#AEF29B# �� Left$	# 132��
$ �� Top$$ -6��z�V� .~��� �� �� $  -371.851Q�T� ._��� -	   % ��Name$% btnSingleGame��
������ & � Cursor$
& Hand��#���  ���#184E5A$��18(�$��Medium"�$��         Single Game���� -
   $ borderAchieve�����	#00000000$��1q�$
��Left=�$��41��$��Bottom=�$	��145��$ 0.5,0.5&����	#FF4981F5$	# 147��$$ 40��z�V� .~��� �� �� $  15.281Q�T� ._��� -   $% btnGetAchievements��
������ $
& Hand��#���  ���	#FFD0FF3D$��18(�$��Medium"�$��Achievements��$��	-12,0,0,0q��� -   $ 
borderExit�����	#00000000$��1q�$
��Left=�$��41��$��Bottom=�$	��145��$ 0.5,0.5&����#218DA6$	# 141��$	$ 173��z�V� .~��� �� �� $  -367.604Q�T� ._��� -   $% btnExit��
������ $��Medium"�$
& Hand��#���  ���	#FFFFA856$��18(�$
��Exit���� -   $ borderRules�����	#00000000$��1q�$
��Left=�$��41��$	��Top=�$	��128��$ 0.5,0.5&����	#FFECE38C$	# 161��$	$ 130��z�V� .~��� �� �� $  11.997Q�T� ._��� -   $% btnRulesGame��
������ $��Medium"�$
& Hand��#���  ���	#FF654070$��18(�$��
Game Rules���� -   $ borderGetCredit�����	#00000000$��1q�$
��Left=�$��41��$��Bottom=�$	��129��$ 0.5,0.5&����	#FF664E9B$	# 163��$$ 86��z�V� .~��� �� �� $  -367.49Q�T� ._��� -   $% btnGetCredit��
������ $��Medium"�$
& Hand��#���  ���	#FFECE38C$��18(�$��
Get Credit��A� -   ' A�Name$' ellipsePlay��$
��Left=�$	��179�����#9BB9BF$��2��$	��Top=�$	��179��$ 0.5,0.5&�$$ 25����
� .��� ( � Color$( 	#FF0477BF��) � Offset$) 1Q�� $( White��� $( 	#FFAED3EA��$	) 0.8Q��� -   $% btnStartGame��#��[ $
��Left=�$��97��$��72��$# 51��$$ 79��.���� $��START��$��14(�$��Medium"�
��������� $
��Left=�$	��119��$��
29,269,0,0q�$	��Top=�$	��552��.+��� -   * ��Name$* txtRules��$��16(�$
��Wrap=�$��Medium"����	#FF654070�� -   + ��Name$+ listAchievements��$y�	Collapsed=����� 3  -RandomThreadRoulette.Controls.UserInfoControl  -   ,  Name$, myUser��$y�	Collapsed=�$
��Left=�$��
404,24,0,0q�$	��Top=�