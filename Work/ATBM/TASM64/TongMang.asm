
.MODEL small
.STACK 100
.DATA 
    A DW 200, 35, 58 ,47
    
    Tong Dw 0 ; 
.CODE
 
start: 
   mov ax, @data
   mov ds, ax
   
   mov si, 0
   mov cx,4
   
   mov ax, 0
TinhTong:
   mov bX, A[si]
   add al,bl
   adc ah,0
   inc si
   INC SI
   loop TinhTong  
   
   mov Tong, ax
   
   
   
   
 ;Ve Dos
   mov ah,4ch
   int 21h     
    
   END start