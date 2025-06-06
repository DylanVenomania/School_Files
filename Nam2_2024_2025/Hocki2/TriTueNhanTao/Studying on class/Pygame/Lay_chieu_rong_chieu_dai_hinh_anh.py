import pygame

pygame.init()

screen = pygame.display.set_mode( (700,700), pygame.RESIZABLE )

screen.fill( (255,255,255) )
pygame.display.set_caption( "Lấy kích thước ảnh")

hinhanh = pygame.image.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")

image_width, image_height = hinhanh.get_size()


print(f"Kích thước ảnh : {image_width}x{image_height}")

screen.blit( hinhanh, (50, 50) )
pygame.display.flip()

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

pygame.quit()
