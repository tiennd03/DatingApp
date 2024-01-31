.model SMALL
.stack 100

arrays  segment
        cost db 20H,28H,15H,26H,19H,27H,16H,29H
        price db 36H,55H,27H,42H,38H,41H,29H,39H
arrays  ends  
code    segment
        assume cs:code, ds:arrays
start:  mov ax,arrays
        mov ds,ax
        lea bx,price
        mov cx,0008H
do_next:mov al,[bx]
        add al,03H
        daa
        mov [bx],al
        inc bx
        dec cx
        jnz do_next
        
        MOV AH,4CH
        INT 21H
code    ends
        end start




