   M S B A M L   `   `   `  ����   RandomThreadRoulette0    *RandomThreadRoulette.Controls.MyMessageBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � SizeToContent$  WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � ShowInTaskbar .   � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Topmost .  � AllowsTransparency . 
������  � 	Resources    greenBackground �� EndPoint	 �� 
StartPoint
 � Color � Offset  yellowBackground  redBackground  blueBackground  btnGlass �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� RenderTransformOrigin � RowDefinitions ��Name �� Triggers P� Property P� Value �� 
TargetName �� ScaleX �� ScaleY�� %�  &	        &	 {     &	 �     &	 q    &	 �    �� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF00BABA��$ 0.012Q�� $
 White��$ 1Q�� $
 	#FFF3F0F0��$ 0.389Q��� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFEFF56E��$ 0.009Q�� $
 White��$ 1Q�� $
 	#FFF0F3F0��$ 0.389Q��� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFFF8A85��$ 0.012Q�� $
 White��$ 1Q�� $
 	#FFF3F0F0��$ 0.389Q��� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF6FA3FD��$ 0.012Q�� $
 White��$ 1Q�� $
 	#FFF3F0F0��$ 0.389Q��� " ��.���  � ��$ 14(���  � ��
 �������  � �� �� " ��.R��� $ ButtonBorder��$ 0��$��4q����	#FF2EC1A6���	#99006391$ 0.5,0.5&�._��  �� $��* ��� $
��1.7* �.+��� $ ButtonContentPresenter��$��Center=�$��Center=�$��2�� P�  � �� . . ��� $ ButtonBorder�� � z� V� .~��� $	 0.9Q�$	 0.9Q�.��� -   $��mainGrid������ $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFD8FFFA��$ 0.012Q�� $
 White��$ 1Q�� $
 	#FFF3F0F0��$ 0.389Q�.+�� $��40��$��	0,102,0,0q�$	��Top=�.+��� -    ��Name$ btnOk��$��Ok��#��[ $
��Left=�$��	187,6,0,0q�$	��Top=�$��75���� -   $ 	btnCancel��$��Cancel��#��[ $��	276,6,0,0q�$	��Top=�$
��Left=�$��74���� $
��Left=�$��87��$��
104,10,0,0q�$	��Top=�$	��265��.+��� -    ��Name$ MessageTitle��$��123123��
�������$��16(� �� TextAlignment$ Center=�$��0,0,0,5q�$
��Bold"�$��CharacterEllipsis=��� -   $ textMessage��$��123123��$
��Wrap=�$��14(�$��Medium"�$��
0,0,-0.8,0q����	#FF574E4E�� -    ��Name$ image��$
��Left=�$��80��$��	10,19,0,0q�$	��Top=�$��80��