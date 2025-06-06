import pygame 
import random
pygame.init()

screen = pygame.display.set_mode(  (400, 400)  )
#tạo cửa sổ có thể cho người dùng thay đổi kích thước
screen = pygame.display.set_mode( (600,600), pygame.RESIZABLE)
#thiết lập màu cho cửa sổ
color = (255, 255, 255)
screen.fill( color )
#cập nhật lại cửa sổ
pygame.display.flip()  #Cập nhật lại toàn bộ, hoặc pygame.update() : cập nhật 1 phần chỉ định



#thiết lập tiêu đề
pygame.display.set_caption( 'Violet Evergarden' )
#thiết lập icon :  pygame.display.set_icon( )



#sử dụng module draw.rect để vẽ các cạnh của hình chữ nhật 
pygame.draw.rect ( screen, (0,0, 255), [100, 100, 400, 100], 2) #số 2 là bề dày của nét vẽ
pygame.draw.rect ( screen, ('black'), [ 150, 130, 300, 40 ] )
pygame.display.update()

#sử dụng module draw.rect để vẽ hình tròn đặc
pygame.draw.circle( screen, ('blue'), [300,420], 170, 0 )
pygame.display.update()

#sử dụng module draw.rect để vẽ đa giác đặc
pygame.draw.polygon( screen, (255,0,0),
                    [ [300,300], [100, 400], 
                        [100, 300] ] )
pygame.display.update()

#sử dụng draw.rect vẽ rectangle 
pygame.draw.rect(screen, ('black'), pygame.Rect(30, 30, 60, 60), border_radius=10)
pygame.display.update()



#Chạy cửa sổ đến khi người dùng tắt
running = True
while running:

    '''
    đổi màu màn hình liên tục
    colortemp = ( random.randint(0, 255) ,random.randint(0, 255) ,random.randint(0, 255)  )
    screen.fill( colortemp)
    pygame.display.flip()
    pygame.time.delay( 500 )
    '''

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False



pygame.display.quit()



