.Model Small
.Stack 100

.Data 
   A DB 03H,04H,08H,07H,09H
   n equ $ - A  
   Max DB 0
    Min DB 0
    TB DB 0


.Code 
    
Start:
     mov ax,@data
     mov ds,ax
     mov si,1
     mov cx,4
     mov bl,a; chuyen phan tu dau tien cua mang vao thanh bl
     mov ax, 0; chay interrupt
     mov es, ax;ch
     mov WORD PTR ES:422, SEG Tr_Binh
     mov WORD PTR ES:420, OFFSET TR_Binh
     INT 105
     mov WORD PTR ES:642, SEG Timmax
     mov WORD PTR ES:640, OFFSET Timmax
     INT 160
     mov WORD PTR ES:602, SEG Timmin
     mov WORD PTR ES:600, OFFSET Timmin
     INT 150
     
     
     mov ah, 4ch
     int 21h
      Tr_Binh    PROC    NEAR
        PUSHF               ;Luu thanh ghi co vao stack
        PUSH AX             ;va cac thanh ghi duoc su dung trong thu tuc
        PUSH BX
        PUSH CX
        PUSH DX
        PUSH BP
        PUSH SI
        PUSH DI
        mov si, 0
        mov cx, 5
        TinhTong:
            mov bl, A[si]
            add ax,bx
            inc si
        loop TinhTong  
        mov bl, n
        div bl
        mov TB, al; bien tb se truyen tham so ra chuong trinh chinh
        
       ;Khoi phuc cac thanh ghi
        POP DI  
        POP SI
        POP BP
        POP DX
        POP CX
        POP BX
        POP AX
        POPF
        RET    ;Tro ve chuong trinh goi
  Tr_Binh     ENDP 
     Timmax   PROC    NEAR  
        PUSHF               ;Luu thanh ghi co vao stack
        PUSH AX             ;va cac thanh ghi duoc su dung trong thu tuc
        PUSH BX
        PUSH CX
        PUSH DX
        PUSH BP
        PUSH SI
        PUSH DI 
VLap:
     mov al,A[si]
     cmp bl,al
     jae TT
     mov bl,al
     TT: add si,1
     loop VLap
    
     mov Max,bl
     
        POP DI  
        POP SI
        POP BP
        POP DX
        POP CX
        POP BX
        POP AX
        POPF
        RET    ;Tro ve chuong trinh goi
    Timmax     ENDP
    Timmin   PROC    NEAR
        PUSHF               ;Luu thanh ghi co vao stack
        PUSH AX             ;va cac thanh ghi duoc su dung trong thu tuc
        PUSH BX
        PUSH CX
        PUSH DX
        PUSH BP
        PUSH SI
        PUSH DI 
        VLap1:
     mov al,A[si]
     cmp bl,al
     jbe TT1
     mov bl,al
     TT1: add si,1
     loop VLap1
    
     mov Min,bl
     
        POP DI  
        POP SI
        POP BP
        POP DX
        POP CX
        POP BX
        POP AX
        POPF
        RET    ;Tro ve chuong trinh goi
        Timmin    ENDP
        

 End Start
  
   
   
   
   
   
    

