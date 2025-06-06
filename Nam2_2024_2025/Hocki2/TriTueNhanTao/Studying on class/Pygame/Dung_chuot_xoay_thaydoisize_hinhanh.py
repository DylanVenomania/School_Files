import pygame

pygame.init()

screen = pygame.display.set_mode((800,600))
pygame.display.set_caption("Dùng chuột xoay và thay đổi kích thước hình ảnh")


image = pygame.image.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")  

original_image = image
image_rect = image.get_rect(center=(800//2, 600//2))

scale_factor = 1.0  
rotation_angle = 0   # Góc xoay
xoay = False  

running = True
while running:
    screen.fill((255, 255, 255))
    
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

        elif event.type == pygame.MOUSEWHEEL:
            if event.y > 0:  
                scale_factor += 0.1
            elif event.y < 0:  
                scale_factor -= 0.1
                if scale_factor < 0.1:  
                    scale_factor = 0.1

        elif event.type == pygame.MOUSEBUTTONDOWN:
            if image_rect.collidepoint(event.pos):  
                xoay = True
                last_mouse_x, last_mouse_y = event.pos  

        elif event.type == pygame.MOUSEBUTTONUP:
            xoay = False
        
        elif event.type == pygame.MOUSEMOTION and xoay:
            mouse_x, mouse_y = event.pos
            dx = mouse_x - last_mouse_x  
            rotation_angle += dx * 0.5  
            last_mouse_x, last_mouse_y = mouse_x, mouse_y  

    new_size = (int(original_image.get_width() * scale_factor), int(original_image.get_height() * scale_factor))
    scaled_image = pygame.transform.scale(original_image, new_size)

    rotated_image = pygame.transform.rotate(scaled_image, rotation_angle)
    
    image_rect = image.get_rect(center=(800//2, 600//2))

    screen.blit(rotated_image, image_rect.topleft)
            
    pygame.display.flip()  


pygame.quit()