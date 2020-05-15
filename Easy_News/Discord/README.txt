# NOTIFICATIONS DISCORD

Le script notify.py sert à notifier des channels Discord dédiés.

### REQUIREMENTS

- python3.5 ou plus
- requests.py
- discord.py

Deux types d'événements sont susceptibles d'être notifiés:

### CI

`python3.8 notify.py 'ci' MESSAGE
`

### MONITORING DU SCRAPER

`python3 notify.py 'scraper' MESSAGE
`

---

Dans les deux cas, MESSAGE représente le texte qui sera envoyé sur le channel de destination.