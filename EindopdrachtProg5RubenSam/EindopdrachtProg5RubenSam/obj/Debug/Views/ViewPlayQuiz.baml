   M S B A M L   `   `   `  ����  EindopdrachtProg5RubenSam2    ,EindopdrachtProg5RubenSam.Views.ViewPlayQuiz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ViewPlayQuiz��5   	   $��327.17��6   $��534.34��6.    � DataContext 5   	   �� *
PlayQuiz+   Locator �� Source# [  .��5      � .+�5   
   �� $
��Next��62   $
��Left=�6A   $��441,255,0,0q�6\   $	��Top=�6q   $��75��6�   ��6   �� *NextQuestion+6�   �� 5   
   $
��Left=�61   $��	94,46,0,0q�6L   $	��Top=�6_   $	��401��6w   ��6   �� *QuestionName+6w   �� 5	   
   $
��Left=�6/   $��	10,38,0,0q�6J   $	��Top=�6]   $y�Hidden=�6u   ��6   �� *
QuestionId+6u   �� 5
   
   $
��Left=�6o   $��75��6�   $��103,112,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *Color1+��6/   �� *Answer1Selected+��6S   �� *	Answer1+6�   �� 5   
   $
��Left=�6o   $��75��6�   $��183,112,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *Color2+��6/   �� *Answer2Selected+��6S   �� *	Answer2+6�   �� 5   
   $
��Left=�6o   $��75��6�   $��263,112,0,0q�6�   $	��Top=�6�   $��75��6�   ��6   �� *Color3+��6/   �� *Answer3Selected+��6S   �� *	Answer3+6�   �� 5   
   $
��Left=�6o   $��75��6�   $��343,112,0,0q�6�   $	��Top=�6�   $��75��6�    J� RenderTransformOrigin$ 
0.96,0.768&�6�   ��6   �� *Color4+��6/   �� *Answer4Selected+��6S   �� *	Answer4+6�   �� 5   
   -   5        $��lblQuizName��5      $
��Left=�6#   $��	23,10,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5        $��	lblQuizID��5      $
��Left=�6N   $��	94,10,0,0q�6i   $	��Top=�6|   $ 4.656,0.471&�6�   ��6!   ��  �� Path$ QuizId� �� Mode$ TwoWay=�6�   5      5      