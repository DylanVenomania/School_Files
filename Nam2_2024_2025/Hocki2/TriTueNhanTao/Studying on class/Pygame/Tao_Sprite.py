import pygame

pygame.init()

rong, cao = 800, 600
screen = pygame.display.set_mode((rong, cao))
pygame.display.set_caption("Tạo Sprite")


class Player(pygame.sprite.Sprite ):
    def __init__(self):
        super().__init__()
        self.image = pygame.Surface((50, 50)) 
        self.image.fill((255, 0, 0)) 
        self.rect = self.image.get_rect(center=(rong // 2, cao // 2)) 
        self.speed = 0.7

    def update(self, keys):
        if keys[pygame.K_LEFT]:
            self.rect.x -= self.speed
        if keys[pygame.K_RIGHT]:
            self.rect.x += self.speed
        if keys[pygame.K_UP]:
            self.rect.y -= self.speed
        if keys[pygame.K_DOWN]:
            self.rect.y += self.speed

player = Player()


all_sprites = pygame.sprite.Group()
all_sprites.add(player)

running = True
while running:
    screen.fill("white") 

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    keys = pygame.key.get_pressed()
    all_sprites.update(keys)

    all_sprites.draw(screen)

    pygame.display.flip() 

pygame.quit()