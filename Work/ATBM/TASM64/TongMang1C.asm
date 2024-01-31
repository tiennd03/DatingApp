
.MODEL small
.STACK 100
.DATA 
    A DB 200, 35, 58 ,47
    
    Tong Dw 0 ; FE (-2)
.CODE
 
start: 
   mov ax, @data
   mov ds, ax
   
   mov si, 0
   mov cx,4
   
   mov ax, 0
TinhTong:
   mov bl, A[si]
   add al,bl
   adc ah,0
   inc si
   loop TinhTong  
   
   mov Tong, ax
   
   
   
   
 ;Ve Dos
   mov ah,4ch
   int 21h     
    
   END start