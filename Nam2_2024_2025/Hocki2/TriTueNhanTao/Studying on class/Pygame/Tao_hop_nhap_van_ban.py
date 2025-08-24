import pygame

pygame.init()

screen = pygame.display.set_mode( (600,400) )
pygame.display.set_caption("Tạo hộp nhập văn bản")

txt_font = pygame.font.Font( None, 20)

input_txt = ""
trangthainhap = False

running = True
while running:
    screen.fill( (255,255,255) )

    pygame.draw.rect( screen, (0,0,0), (50, 150, 500, 50 ), 2)

  

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
            
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if 50 <= event.pos[0] <= 550 and 150 <= event.pos[1] <= 200 :
                trangthainhap = True


        elif event.type == pygame.KEYDOWN and trangthainhap:
            if event.key == pygame.K_RETURN :
                print("Đã nhập ", input_txt)
                input_txt = ""
            elif event.key == pygame.K_BACKSPACE:
                input_txt = input_txt[ :-1 ]
            else:
                input_txt += event.unicode

    txt_surface = txt_font.render( input_txt, True, (0,0,0) )
    
    screen.blit( txt_surface, (60,160) )
    pygame.display.flip()
        

pygame.quit