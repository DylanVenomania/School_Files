import pygame

pygame.init()

screen = pygame.display.set_mode((800,600))
pygame.display.set_caption("Xoay và thay đổi kích thước hình ảnh")


image = pygame.image.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")  
resized_image = pygame.transform.scale(image, (300, 200))

rotated_image = pygame.transform.rotate(resized_image, 45)

image_rect = rotated_image.get_rect(center=(800 // 2, 600 // 2))

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    screen.fill((255, 255, 255)) 
    screen.blit(rotated_image, image_rect.topleft)

    pygame.display.flip()  

pygame.quit()