// https://commitlint.js.org/reference/configuration.html
/** @type {import('@commitlint/types').UserConfig} */
module.exports = {
  extends: ['@commitlint/config-conventional'],
  rules: {
    // Enforce the types declared in cliff.toml
    'type-enum': [
      2,
      'always',
      [
        'feat',
        'fix',
        'docs',
        'perf',
        'refactor',
        'test',
        'ci',
        'chore',
        'revert',
        'security',
        'breaking',
      ],
    ],
    // Subject line must not end with a period
    'subject-full-stop': [2, 'never', '.'],
    // Subject line must start in lower-case (conventional commits style)
    'subject-case': [2, 'never', ['sentence-case', 'start-case', 'pascal-case', 'upper-case']],
    // Body and footer lines must be wrapped at 100 characters
    'body-max-line-length': [2, 'always', 100],
  },
};

