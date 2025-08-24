import pygame

pygame.init()
screen = pygame.display.set_mode((600, 400))
pygame.display.set_caption("Thay đổi màu sắc khi nhấn phím")

colors = [(255, 0, 0), (0, 255, 0), (0, 0, 255), (255, 255, 0)]
current_color = 0

running = True
while running:
    screen.fill((255, 255, 255))  

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            current_color = (current_color + 1) % len(colors)  
    pygame.draw.rect(screen, colors[current_color], (250, 150, 100, 100))

    pygame.display.flip()

pygame.quit()