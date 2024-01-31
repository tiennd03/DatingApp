.model small
.stack 100
.data 
CODE SEGMENT
     ASSUME CS:CODE
start:    
         mov bl, '5'
         mov al,'9'
         and al,0FH
         AND bl,0fh
         mov cl,04h
         rol bl,cl
         or al,bl
         
         mov ah,4ch
         int 21h 
CODE ENDS
END START