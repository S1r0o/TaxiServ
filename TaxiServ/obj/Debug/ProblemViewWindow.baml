   M S B A M L   `   `   `  ����C  ?TaxiServ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TaxiServTaxiServ  5   	        TaxiServ.ProblemViewWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TaxiServ     5   	     � Title$  ProblemViewWindow��5   	   $	��550��6#   $	��800��60    � 
ResizeMode$ NoResize=�6<   .��5	      � .+�5
   
   �� -   5         ��Name$ 	Logo_auth��5
      $��Right=�6#   $��50��6?   $	��Top=�6K   $��49��6c   $��
0,11,692,0q�6n   �� 5   
   $)��#Просмотр обращения��6   $��Center=�6-   $	��Top=�6J   $	��300��6b   $��40��6n   $��Center=�6z   $��Center=�6�   $��Times New Roman)�6�   $��26(�6�   $��0,11,0,0q�6�   �� 5   
   $)��#Заголовок проблемы��6   $
��Left=�6-   $	��Top=�6H   $
��Left=�6`   $��Center=�6�   $��Times New Roman)�6�   $��24(�6�   $��	20,67,0,0q�6�   �� 5   
   -   5         ��Name$ TitleBox��5      $	��310��6$   $��30��60   $
��Left=�6<   ���	#FFE8D6B7$��Bottom=�6n    �� TextWrapping$
 Wrap=�6�   $��Times New Roman)�6�   $��16(�6�   $
��Left=�6�   $��Center=�6	  $��
20,0,0,377q�6+  ��6�   �� *title_problem+6+  �� 5   
   $'��!Описание проблемы��6   $
��Left=�6,   $	��Top=�6G   $
��Left=�6_   $��Center=�6�   $��Times New Roman)�6�   $��24(�6�   $��
20,259,0,0q�6�   $��36��6�   �� 5   
   -   5        $ DescriptionBox��5      $	��428��6*   $��86��66   $
��Left=�6B   $	��Top=�6]   ���	#FFE8D6B7$
 Wrap=�6�   $��Times New Roman)�6�   $��16(�6�   $
��Left=�6�   $��
20,313,0,0q�6
  ��6�   �� *description+6
  �� 5   
   $'��!Версия приложения��6   $
��Left=�6,   $	��Top=�6G   $
��Left=�6_   $��Center=�6�   $��Times New Roman)�6�   $��24(�6�   $��
464,67,0,0q�6�   �� 5   
   -   5        $ 
VersionBox��5      $	��310��6&   $��30��62   $
��Left=�6>   $��Bottom=�6Y   ���	#FFE8D6B7$
 Wrap=�6�   $��Times New Roman)�6�   $��16(�6�   $
��Left=�6�   $��Center=�6  $��464,0,0,377q�6'  ��6�   �� *	version+6'  �� 5   
   $��Девайс��6   $
��Left=�6!   $	��Top=�6<   $
��Left=�6T   $��Center=�6v   $��Times New Roman)�6�   $��24(�6�   $��464,162,0,0q�6�   �� 5   
   -   5        $ 	DeviceBox��5      $	��310��6%   $��30��61   $
��Left=�6=   $��Bottom=�6X   ���	#FFE8D6B7$
 Wrap=�6�   $��Times New Roman)�6�   $��16(�6�   $
��Left=�6�   $��Center=�6  $��464,0,0,280q�6%  ��6�   �� *device+6%  �� 5   
   $��
Время��6   $
��Left=�6    $	��Top=�6;   $
��Left=�6S   $��Center=�6u   $��Times New Roman)�6�   $��24(�6�   $��
20,162,0,0q�6�   �� 5   
   -   5        $ TimeBox��5      $	��310��6#   $��30��6/   $
��Left=�6;   ���	#FFE8D6B7$��Bottom=�6m   $
 Wrap=�6�   $��Times New Roman)�6�   $��16(�6�   $
��Left=�6�   $��Center=�6�   $��
20,0,0,280q�6!  ��6�   �� *time+6!  �� 5   
   $��Заявитель��6   $
��Left=�6$   $	��Top=�6?   $
��Left=�6W   $��Center=�6y   $��Times New Roman)�6�   $��24(�6�   $��464,313,0,0q�6�   $��36��6�   �� 5   
   -   5         ��Name$ 	Applicant��5      $
��Left=�6&   $��Bottom=�6A   $	��310��6\   $��30��6h    �� DisplayMemberPath$
 name��6t   $��Times New Roman)�6�   $��16(�6�   $��464,0,0,135q�6�    �� SelectedItem 6�   �� *
Applicant1+6�   �� 5   
   -   5         ��Name$ CreateBytton��5      $'��!Создать обращение��6'   $
��Left=�6C   $	��Top=�6^   $	��155��6v   $��40��6�   $��18(�6�   $��Times New Roman)�6�   $��619,422,0,0q�6�   6�   �� 5   
   -	   5        $ 
SaveButton��5      $+��%Сохранить изменения��6%   $	��Top=�6C   $��40��6[   $��18(�6g   $��Times New Roman)�6u   $��20,422,580,0q�6�   5      5      