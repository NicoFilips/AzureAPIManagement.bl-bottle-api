# BierAPI
Eine API zur Abfrage von Biersorten und einigen Funktionen

```mermaid
sequenceDiagram
    autonumber
    Note right of Frontend: Ich brauche Infos über Bier!
    Frontend->>Backend: Gib mir Infos über das beste Bier!
    Backend->>Flapotest: GetBierData
    Flapotest-->>Backend: Bier JSON
    loop was ist das beste Bier
        Backend->>Backend: Brrrr 
    end
    Backend-->>Frontend: Augustiner!
```
