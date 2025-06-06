import pygame

pygame.init()

screen = pygame.display.set_mode((800,600))
pygame.display.set_caption("Di chuyển hình ảnh bằng kéo thả")


image = pygame.image.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")  

image_rect = image.get_rect(topleft=(100, 100) )

keotha = False

running = True
while running:
    screen.fill((255, 255, 255))
    screen.blit(image, image_rect.topleft)
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        elif event.type == pygame.MOUSEBUTTONDOWN: 
            if image_rect.collidepoint(event.pos):  
                keotha = True
                mouse_x, mouse_y = event.pos  
                offset_x = image_rect.x - mouse_x  
                offset_y = image_rect.y - mouse_y

        elif event.type == pygame.MOUSEBUTTONUP: 
            keotha = False

        elif event.type == pygame.MOUSEMOTION:  
            if keotha:
                mouse_x, mouse_y = event.pos
                image_rect.x = mouse_x + offset_x  
                image_rect.y = mouse_y + offset_y

    pygame.display.flip()  


pygame.quit()