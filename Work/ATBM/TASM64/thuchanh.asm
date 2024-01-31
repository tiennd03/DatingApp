.MODEL small
.STACK 100
.DATA 
    A DB -8H,15H,-22H,14H,-7H
    B DB -9H,-25H,40H,12H,-26H
    n equ $ - A
    
.CODE
 
start: 
   mov ax, @data
   mov ds, ax
   mov si, 0
   mov cx,5
   
   mov ax, 0
TinhTich:
   mov al, A[si]
   mov bl,B[si]
   cmp al, 0 
   cmp bl, 0 
   jl multiply         ; N?u gi? tr? nh? h?n 0, nh?y t?i nh?n multiply
    jmp next_element    ; N?u gi? tr? l?n h?n ho?c b?ng 0, nh?y t?i nh?n next_element

    multiply:
    imul bl ; Nh?n ph?n t? ?m c?a m?ng A v?i bi?n t?ch trong thanh ghi bl
    jmp next_element    ; Nh?y t?i nh?n next_element sau khi th?c hi?n nh?n

    next_element:
    inc si             ; T?ng con tr? m?ng A l?n 1 byte
    add cx, 2          ; T?ng con tr? m?ng C l?n 2 bytes

    loop TinhTich
   mov ah,4ch
     int 21h

     end start