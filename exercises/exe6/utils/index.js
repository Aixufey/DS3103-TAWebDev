








export const queryHero = (select) => {
    return document.querySelector(select);
}

// Pass in class to external module

export const htmlElements = {
    hero: queryHero('.hero-container'),
}
// htmlElements.hero.addEventListener('click', () => alert('Hello 1'))

// Pass in statically
export const defined = {
    hero: document.querySelector('.hero-container'),
}
// defined.hero.addEventListener('click', () => alert('Hello 2'))

// Pass in dynamically
export const dynamicCreated = {
    tag: (select) => {
        return document.querySelector(select);
    }
}

// dynamicCreated.tag('.hero-container').addEventListener('click', () => alert('Hello 3'))

