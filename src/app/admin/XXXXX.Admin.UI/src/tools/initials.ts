export function initials(first: string, second: string | null = null): string {
    let initials = "";
    const ALL_SPACES_REGEX = /^ *$/;
    const SPLIT_REGEX = /[s-]+/;

    // If the string is not null or is not just spaces
    if (!(first == null || first.match(ALL_SPACES_REGEX) !== null)) {
        // Split the string on 's' and '-' (wtf ?)
        let splitFirst = first.trim().split(SPLIT_REGEX); // Sorry Guillaume but your code was not functionning
        if (splitFirst.length > 0) {
            initials += splitFirst[0][0];
        }
        if (splitFirst.length > 1) {
            initials += splitFirst[1][0];
        }
    }

    if (!(second == null || second.match(ALL_SPACES_REGEX) !== null)) {
        let splitSecond = second.trim().split(SPLIT_REGEX);
        if (splitSecond.length > 0) {
            initials += splitSecond[0][0];
        }
    }

    return initials;
}

export function initialsV2(first: string, second: string | null = null): string {
    let initials = "";
    const SPLIT_REGEX = /[-]+/; // Detects all '-'

    // If the string is not null or not only spaces / newlines
    if (!!first?.trim()) {
        // Split the string on '-'
        const splittedFirst = first.trim().split(SPLIT_REGEX);

        if (splittedFirst.length > 0)
            initials += splittedFirst[0].charAt(0);

        if (splittedFirst.length > 1)
            initials += splittedFirst[1].charAt(0);
    }

    if (!!second?.trim()) {
        const splittedSecond = second.trim().split(SPLIT_REGEX);

        if (splittedSecond.length > 0)
            initials += splittedSecond[0].charAt(0);
    }

    return initials;
}