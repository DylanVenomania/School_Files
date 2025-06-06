import pygame

pygame.init()

screen = pygame.display.set_mode( (700,700), pygame.RESIZABLE)
screen.fill( ( 255,255,255) )

pygame.display.set_caption("Hiển thị hình ảnh trong pygame")

hinhanh = pygame.image.load (r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")



screen.blit( hinhanh, (50,50) )
pygame.display.flip()

running = True
while running :
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

pygame.quit()